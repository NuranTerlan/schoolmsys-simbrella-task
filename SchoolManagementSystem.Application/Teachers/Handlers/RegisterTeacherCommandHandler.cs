using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Application.BaseIdentity;
using SchoolManagementSystem.Application.BaseIdentity.DTOs;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Options;
using SchoolManagementSystem.Application.Teachers.Commands;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Teachers.Handlers
{
    public class RegisterTeacherCommandHandler :
        IRequestHandlerWrapper<RegisterTeacherCommand, AuthResultDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public RegisterTeacherCommandHandler(UserManager<ApplicationUser> userManager,
            IMapper mapper, JwtSettings jwtSettings, IApplicationDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtSettings = jwtSettings;
            _context = context;
        }

        public async Task<Response<AuthResultDto>> Handle(RegisterTeacherCommand request, CancellationToken cancellationToken)
        {
            var existingTeacher = await _userManager.FindByEmailAsync(request.Email);

            if (existingTeacher != null)
            {
                return Response.Fail<AuthResultDto>($"User with this email ({request.Email} already exists)");
            }

            try
            {
                var newUser = _mapper.Map<Teacher>(request);
                newUser.NormalizedEmail = request.Email.ToUpper();
                var ph = new PasswordHasher<Teacher>();
                newUser.PasswordHash = ph.HashPassword(newUser, request.Password);
                await _context.Teachers.AddAsync(newUser, cancellationToken);
                var isAdded = await _context.SaveChangesAsync(cancellationToken);
                if (isAdded == 0)
                {
                    return Response.Fail<AuthResultDto>("Problem occured while creating user entity");
                }

                await _userManager.AddToRoleAsync(newUser, "Teacher");

                var result = new AuthResultDto
                {
                    Token = JwtTokenGenerator.GenerateToken(newUser.Email, newUser.Id,
                        _jwtSettings.Secret, "Teacher")
                };
                return Response.Success<AuthResultDto>(result, "Token is created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
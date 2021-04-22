using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.BaseIdentity;
using SchoolManagementSystem.Application.BaseIdentity.DTOs;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Options;
using SchoolManagementSystem.Application.Students.Commands;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Students.Handlers
{
    public class RegisterStudentCommandHandler :
        IRequestHandlerWrapper<RegisterStudentCommand, AuthResultDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public RegisterStudentCommandHandler(UserManager<ApplicationUser> userManager, 
            IMapper mapper, JwtSettings jwtSettings, IApplicationDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtSettings = jwtSettings;
            _context = context;
        }

        public async Task<Response<AuthResultDto>> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            var schoolClass = await _context.SchoolClasses.AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == request.SchoolClassId, cancellationToken);
            if (schoolClass is null)
            {
                return Response.Fail<AuthResultDto>(
                    $"In our school we don't have class with Id#{request.SchoolClassId}");
            }

            var existingStudent = await _userManager.FindByEmailAsync(request.Email);

            if (existingStudent != null)
            {
                return Response.Fail<AuthResultDto>($"User with this email ({request.Email} already exists)");
            }

            try
            {
                var newUser = _mapper.Map<Student>(request);
                newUser.NormalizedEmail = request.Email.ToUpper();
                var ph = new PasswordHasher<Student>();
                newUser.PasswordHash = ph.HashPassword(newUser, request.Password);
                newUser.SchoolClassId = request.SchoolClassId;
                await _context.Students.AddAsync(newUser, cancellationToken);
                var isAdded = await _context.SaveChangesAsync(cancellationToken);
                if (isAdded == 0)
                {
                    return Response.Fail<AuthResultDto>("Problem occured while creating user entity");
                }

                await _userManager.AddToRoleAsync(newUser, "Student");

                var result = new AuthResultDto
                {
                    Token = JwtTokenGenerator.GenerateToken(newUser.Email, newUser.Id,
                        _jwtSettings.Secret, "Student")
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
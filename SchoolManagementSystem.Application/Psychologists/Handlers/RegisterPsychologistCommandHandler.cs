using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Application.BaseIdentity;
using SchoolManagementSystem.Application.BaseIdentity.DTOs;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Options;
using SchoolManagementSystem.Application.Psychologists.Commands;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Psychologists.Handlers
{
    public class RegisterPsychologistCommandHandler : 
        IRequestHandlerWrapper<RegisterPsychologistCommand, AuthResultDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public RegisterPsychologistCommandHandler(UserManager<ApplicationUser> userManager,
            IMapper mapper, JwtSettings jwtSettings, IApplicationDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtSettings = jwtSettings;
            _context = context;
        }

        public async Task<Response<AuthResultDto>> Handle(RegisterPsychologistCommand request, CancellationToken cancellationToken)
        {
            var existingPsychologist = await _userManager.FindByEmailAsync(request.Email);

            if (existingPsychologist != null)
            {
                return Response.Fail<AuthResultDto>($"User with this email ({request.Email} already exists)");
            }

            try
            {
                var newUser = _mapper.Map<Psychologist>(request);
                newUser.NormalizedEmail = request.Email.ToUpper();
                var ph = new PasswordHasher<Psychologist>();
                newUser.PasswordHash = ph.HashPassword(newUser, request.Password);
                await _context.Psychologists.AddAsync(newUser, cancellationToken);
                var isAdded = await _context.SaveChangesAsync(cancellationToken);
                if (isAdded == 0)
                {
                    return Response.Fail<AuthResultDto>("Problem occured while creating user entity");
                }

                await _userManager.AddToRoleAsync(newUser, "Psychologist");

                var result = new AuthResultDto
                {
                    Token = JwtTokenGenerator.GenerateToken(newUser.Email, newUser.Id,
                        _jwtSettings.Secret, "Psychologist")
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
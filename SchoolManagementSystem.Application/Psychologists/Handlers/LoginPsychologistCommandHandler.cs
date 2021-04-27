using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Application.BaseIdentity;
using SchoolManagementSystem.Application.BaseIdentity.DTOs;
using SchoolManagementSystem.Application.Options;
using SchoolManagementSystem.Application.Psychologists.Commands;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Commons;

namespace SchoolManagementSystem.Application.Psychologists.Handlers
{
    public class LoginPsychologistCommandHandler :
        IRequestHandlerWrapper<LoginPsychologistCommand, AuthResultDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public LoginPsychologistCommandHandler(UserManager<ApplicationUser> userManager,
            JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<Response<AuthResultDto>> Handle(LoginPsychologistCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return Response.Fail<AuthResultDto>("User doesn't exist!");
            }

            var passwordIsValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!passwordIsValid)
            {
                return Response.Fail<AuthResultDto>("Password is wrong!");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var role = userRoles.Contains("Admin") ? "Admin" : "Psychologist";

            var result = new AuthResultDto
            {
                Token = JwtTokenGenerator.GenerateToken(user.Email, user.Id,
                    _jwtSettings.Secret, role)
            };
            return Response.Success<AuthResultDto>(result, "Token is created successfully");
        }
    }
}
using SchoolManagementSystem.Application.BaseIdentity.Commands;
using SchoolManagementSystem.Application.BaseIdentity.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Psychologists.Commands
{
    public class LoginPsychologistCommand : IRequestWrapper<AuthResultDto>, IUserLoginCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
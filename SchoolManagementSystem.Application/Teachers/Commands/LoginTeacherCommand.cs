using SchoolManagementSystem.Application.BaseIdentity.Commands;
using SchoolManagementSystem.Application.BaseIdentity.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Teachers.Commands
{
    public class LoginTeacherCommand : IRequestWrapper<AuthResultDto>, IUserLoginCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
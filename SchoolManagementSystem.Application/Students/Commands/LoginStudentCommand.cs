using SchoolManagementSystem.Application.BaseIdentity.Commands;
using SchoolManagementSystem.Application.BaseIdentity.DTOs;
using SchoolManagementSystem.Application.Students.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Students.Commands
{
    public class LoginStudentCommand : IRequestWrapper<AuthResultDto>, IUserLoginCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
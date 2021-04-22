using SchoolManagementSystem.Application.BaseIdentity.Commands;
using SchoolManagementSystem.Application.BaseIdentity.DTOs;
using SchoolManagementSystem.Application.Students.DTOs;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Enumerations;

namespace SchoolManagementSystem.Application.Students.Commands
{
    public class RegisterStudentCommand : IRequestWrapper<AuthResultDto>, IUserRegisterCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short BirthYear { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public int SchoolClassId { get; set; }
        public string Password { get; set; }
    }
}
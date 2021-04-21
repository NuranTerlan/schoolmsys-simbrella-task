using SchoolManagementSystem.Domain.Enumerations;

namespace SchoolManagementSystem.Application.BaseIdentity.Commands
{
    public interface IUserRegisterCommand
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        short BirthYear { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        Gender Gender { get; set; }
        string Password { get; set; }
    }
}
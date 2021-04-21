namespace SchoolManagementSystem.Application.BaseIdentity.Commands
{
    public interface IUserLoginCommand
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}
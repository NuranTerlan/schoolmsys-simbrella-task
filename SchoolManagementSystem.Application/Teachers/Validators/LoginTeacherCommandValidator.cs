using SchoolManagementSystem.Application.BaseIdentity.Validators;
using SchoolManagementSystem.Application.Teachers.Commands;

namespace SchoolManagementSystem.Application.Teachers.Validators
{
    public class LoginTeacherCommandValidator : LoginCommandValidator<LoginTeacherCommand>
    {
        public LoginTeacherCommandValidator()
            :base()
        {
        }
    }
}
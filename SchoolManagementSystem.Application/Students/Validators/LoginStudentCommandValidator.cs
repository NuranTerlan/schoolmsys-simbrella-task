using FluentValidation;
using FluentValidation.Validators;
using SchoolManagementSystem.Application.BaseIdentity.Validators;
using SchoolManagementSystem.Application.Students.Commands;

namespace SchoolManagementSystem.Application.Students.Validators
{
    public class LoginStudentCommandValidator : LoginCommandValidator<LoginStudentCommand>
    {
        public LoginStudentCommandValidator()
            :base()
        {
        }
    }
}
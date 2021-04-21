using SchoolManagementSystem.Application.BaseIdentity.Validators;
using SchoolManagementSystem.Application.Teachers.Commands;

namespace SchoolManagementSystem.Application.Teachers.Validators
{
    public class RegisterTeacherCommandValidator : RegisterCommandValidator<RegisterTeacherCommand>
    {
        public RegisterTeacherCommandValidator()
            :base()
        {
        }
    }
}
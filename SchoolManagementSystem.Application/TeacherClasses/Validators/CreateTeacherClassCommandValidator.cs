using FluentValidation;
using FluentValidation.Validators;
using SchoolManagementSystem.Application.TeacherClasses.Commands;

namespace SchoolManagementSystem.Application.TeacherClasses.Validators
{
    public class CreateTeacherClassCommandValidator : AbstractValidator<CreateTeacherClassCommand>
    {
        public CreateTeacherClassCommandValidator()
        {
            RuleFor(c => c.CourseId).GreaterThan(0);
            RuleFor(c => c.SchoolClassId).GreaterThan(0);
            RuleFor(c => c.TeacherEmail).NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(c => c.From).NotEmpty();
            RuleFor(c => c.To).NotEmpty();
        }
    }
}
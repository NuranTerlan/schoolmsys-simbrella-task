using FluentValidation;
using SchoolManagementSystem.Application.Courses.Commands;
using SchoolManagementSystem.Application.SchoolClasses.Commands;

namespace SchoolManagementSystem.Application.SchoolClasses.Validators
{
    public class CreateSchoolClassCommandValidator : AbstractValidator<CreateSchoolClassCommand>
    {
        public CreateSchoolClassCommandValidator()
        {
            RuleFor(c => c.Title).NotEmpty().MinimumLength(2);
            RuleFor(c => c.RoomNumber).NotEmpty();
            RuleFor(c => c.PsychologistId).NotEmpty();
        }
    }
}
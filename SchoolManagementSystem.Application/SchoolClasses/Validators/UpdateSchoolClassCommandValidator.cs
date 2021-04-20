using FluentValidation;
using SchoolManagementSystem.Application.SchoolClasses.Commands;

namespace SchoolManagementSystem.Application.SchoolClasses.Validators
{
    public class UpdateSchoolClassCommandValidator : AbstractValidator<UpdateSchoolClassCommand>
    {
        public UpdateSchoolClassCommandValidator()
        {
            RuleFor(c => c.Title).NotEmpty().MinimumLength(3);
            RuleFor(c => c.RoomNumber).NotEmpty();
        }
    }
}
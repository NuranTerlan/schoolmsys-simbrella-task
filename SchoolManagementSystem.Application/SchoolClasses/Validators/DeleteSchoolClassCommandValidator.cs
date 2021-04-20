using FluentValidation;
using SchoolManagementSystem.Application.SchoolClasses.Commands;

namespace SchoolManagementSystem.Application.SchoolClasses.Validators
{
    public class DeleteSchoolClassCommandValidator : AbstractValidator<DeleteSchoolClassCommand>
    {
        public DeleteSchoolClassCommandValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0);
        }
    }
}
using FluentValidation;
using SchoolManagementSystem.Application.Courses.Commands;

namespace SchoolManagementSystem.Application.Courses.Validators
{
    public class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0);
        }
    }
}
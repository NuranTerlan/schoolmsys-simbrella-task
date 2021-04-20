using FluentValidation;
using SchoolManagementSystem.Application.Courses.Commands;

namespace SchoolManagementSystem.Application.Courses.Validators
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
        }
    }
}
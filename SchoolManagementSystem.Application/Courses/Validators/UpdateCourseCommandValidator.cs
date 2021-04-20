using FluentValidation;
using SchoolManagementSystem.Application.Courses.Commands;

namespace SchoolManagementSystem.Application.Courses.Validators
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
        }
    }
}
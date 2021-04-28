using FluentValidation;
using SchoolManagementSystem.Application.Students.Commands;

namespace SchoolManagementSystem.Application.Students.Validators
{
    public class DecreaseStudentAbsentMarkCommandValidator : AbstractValidator<DecreaseStudentAbsentMarkCommand>
    {
        public DecreaseStudentAbsentMarkCommandValidator()
        {
            RuleFor(c => c.StudentId).NotEmpty();
            RuleFor(c => c.Count).GreaterThan((byte)0);
        }
    }
}
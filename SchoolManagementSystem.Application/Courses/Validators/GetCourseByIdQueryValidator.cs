using FluentValidation;
using SchoolManagementSystem.Application.Courses.Queries;

namespace SchoolManagementSystem.Application.Courses.Validators
{
    public class GetCourseByIdQueryValidator : AbstractValidator<GetCourseByIdQuery>
    {
        public GetCourseByIdQueryValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0);
        }
    }
}
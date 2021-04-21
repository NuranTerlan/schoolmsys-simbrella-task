using FluentValidation;
using SchoolManagementSystem.Application.Teachers.Queries;

namespace SchoolManagementSystem.Application.Teachers.Validators
{
    public class GetTeacherByIdQueryValidator : AbstractValidator<GetTeacherByIdQuery>
    {
        public GetTeacherByIdQueryValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
        }
    }
}
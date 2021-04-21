using FluentValidation;
using SchoolManagementSystem.Application.Students.Queries;

namespace SchoolManagementSystem.Application.Students.Validators
{
    public class GetStudentByIdQueryValidator : AbstractValidator<GetStudentByIdQuery>
    {
        public GetStudentByIdQueryValidator()
        {
            RuleFor(s => s.Id).NotEmpty();
        }
    }
}
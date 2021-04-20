using FluentValidation;
using SchoolManagementSystem.Application.SchoolClasses.Queries;

namespace SchoolManagementSystem.Application.SchoolClasses.Validators
{
    public class GetSchoolClassByIdQueryValidator : AbstractValidator<GetSchoolClassByIdQuery>
    {
        public GetSchoolClassByIdQueryValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0);
        }
    }
}
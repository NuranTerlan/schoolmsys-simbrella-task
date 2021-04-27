using FluentValidation;
using SchoolManagementSystem.Application.Psychologists.Queries;

namespace SchoolManagementSystem.Application.Psychologists.Validators
{
    public class GetPsychologistByIdQueryValidator : AbstractValidator<GetPsychologistByIdQuery>
    {
        public GetPsychologistByIdQueryValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
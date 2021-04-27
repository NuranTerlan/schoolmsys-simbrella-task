using SchoolManagementSystem.Application.BaseIdentity.Validators;
using SchoolManagementSystem.Application.Psychologists.Commands;

namespace SchoolManagementSystem.Application.Psychologists.Validators
{
    public class RegisterPsychologistCommandValidator : RegisterCommandValidator<RegisterPsychologistCommand>
    {
        public RegisterPsychologistCommandValidator()
            :base()
        {
            
        }
    }
}
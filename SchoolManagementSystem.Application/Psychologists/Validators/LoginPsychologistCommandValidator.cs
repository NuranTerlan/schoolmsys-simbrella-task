using SchoolManagementSystem.Application.BaseIdentity.Validators;
using SchoolManagementSystem.Application.Psychologists.Commands;

namespace SchoolManagementSystem.Application.Psychologists.Validators
{
    public class LoginPsychologistCommandValidator : LoginCommandValidator<LoginPsychologistCommand>
    {
        public LoginPsychologistCommandValidator()
            :base()
        {
            
        }
    }
}
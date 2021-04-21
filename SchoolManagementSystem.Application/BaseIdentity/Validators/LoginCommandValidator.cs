using FluentValidation;
using FluentValidation.Validators;
using SchoolManagementSystem.Application.BaseIdentity.Commands;

namespace SchoolManagementSystem.Application.BaseIdentity.Validators
{
    public class LoginCommandValidator<T> : AbstractValidator<T>
        where T : IUserLoginCommand
    {
        public LoginCommandValidator()
        {
            RuleFor(c => c.Email).NotEmpty().EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(c => c.Password).NotEmpty()
                .MinimumLength(5).MaximumLength(20);
        }
    }
}
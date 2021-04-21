using System;
using FluentValidation;
using FluentValidation.Validators;
using SchoolManagementSystem.Application.BaseIdentity.Commands;

namespace SchoolManagementSystem.Application.BaseIdentity.Validators
{
    public class RegisterCommandValidator<T> : AbstractValidator<T> 
        where T : IUserRegisterCommand
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty()
                .MinimumLength(2).MaximumLength(100);
            RuleFor(c => c.LastName).NotEmpty()
                .MinimumLength(2).MaximumLength(100);
            RuleFor(c => c.BirthYear)
                .GreaterThan((short)1900)
                .LessThan((short)(DateTime.UtcNow.Year - 6));
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.Email).NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(c => c.Gender)
                .Must(g => (int)g == 1 || (int)g == 2);
            RuleFor(c => c.Password).NotEmpty()
                .MinimumLength(5).MaximumLength(20);
        }
    }
}
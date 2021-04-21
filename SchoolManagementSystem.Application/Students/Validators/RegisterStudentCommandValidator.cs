using System;
using FluentValidation;
using FluentValidation.Validators;
using SchoolManagementSystem.Application.BaseIdentity.Validators;
using SchoolManagementSystem.Application.Students.Commands;

namespace SchoolManagementSystem.Application.Students.Validators
{
    public class RegisterStudentCommandValidator : RegisterCommandValidator<RegisterStudentCommand>
    {
        public RegisterStudentCommandValidator()
            :base()
        {
            RuleFor(s => s.SchoolClassId)
                .GreaterThan(0);
        }
    }
}
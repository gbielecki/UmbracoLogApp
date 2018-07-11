using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmbracoLogApp.Models.FormModels;

namespace UmbracoLogApp.Models.Validator
{
    public class RegistrationModelValidator : AbstractValidator<RegistrationFormModel>
    {
        public RegistrationModelValidator()
        {
            RuleFor(member => member.Email).Must(Common.BeAValidEmail).WithMessage("Please specify a valid emial address");
            RuleFor(member => member.Password).NotEmpty().WithMessage("Please specify a password");
            RuleFor(member => member.PasswordConfirmation).NotEmpty().WithMessage("Please specify a password confirmation");
            RuleFor(member => member.Password).Equal(member => member.PasswordConfirmation).WithMessage("Password and password confirmation must match");
        }
    }
}
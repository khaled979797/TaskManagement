using FluentValidation;
using TaskManagement.Core.Features.Users.Commands.Models;

namespace TaskManagement.Core.Features.Users.Commands.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName should not be empty")
                .NotNull().WithMessage("UserName should not be null");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password should not be empty")
                .NotNull().WithMessage("Password should not be null");
        }
    }
}

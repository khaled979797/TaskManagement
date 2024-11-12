using FluentValidation;
using TaskManagement.Core.Features.Users.Commands.Models;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Users.Commands.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUserRepository userRepository;

        public RegisterUserValidator(IUserRepository userRepository)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            this.userRepository = userRepository;
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .NotNull().WithMessage("Name should not be null");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName should not be empty")
                .NotNull().WithMessage("UserName should not be null");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email should not be empty")
                .EmailAddress().WithMessage("Email is not valid")
                .NotNull().WithMessage("Email should not be null");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password should not be empty")
                .NotNull().WithMessage("Password should not be null");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("ConfirmPassword should not be empty")
                .NotNull().WithMessage("ConfirmPassword should not be null")
                .Matches(x => x.Password).WithMessage("ConfirmPassword should mactch password");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.UserName)
                .MustAsync(async (Key, CancellationToken) => !await userRepository.IsUserNameExist(Key))
                .WithMessage("UserName is already exist");
            RuleFor(x => x.Email)
                .MustAsync(async (Key, CancellationToken) => !await userRepository.IsEmailExist(Key))
                .WithMessage("Email is already exist");
        }
    }
}

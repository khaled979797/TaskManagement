using FluentValidation;
using TaskManagement.Core.Features.Users.Commands.Models;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Users.Commands.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        private readonly IUserRepository userRepository;

        public EditUserValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .NotEmpty().WithMessage("Id should not be empty")
                .NotNull().WithMessage("Id should not be null");

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
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.UserName)
                .MustAsync(async (model, Key, CancellationToken) => !await userRepository.IsUserNameExistExcludeSelf(Key, model.Id))
                .WithMessage("UserName is already exist");

            RuleFor(x => x.Email)
                .MustAsync(async (model, Key, CancellationToken) => !await userRepository.IsEmailExistExcludeSelf(Key, model.Id))
                .WithMessage("Email is already exist");
        }
    }
}

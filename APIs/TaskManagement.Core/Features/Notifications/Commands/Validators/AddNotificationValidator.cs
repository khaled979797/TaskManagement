using FluentValidation;
using TaskManagement.Core.Features.Notifications.Commands.Models;

namespace TaskManagement.Core.Features.Notifications.Commands.Validators
{
    public class AddNotificationValidator : AbstractValidator<AddNotificationCommand>
    {
        public AddNotificationValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message should not be empty")
                .NotNull().WithMessage("Message should not be null");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId should be greater than zero")
                .NotEmpty().WithMessage("UserId should not be empty")
                .NotNull().WithMessage("UserId should not be null");
        }
    }
}

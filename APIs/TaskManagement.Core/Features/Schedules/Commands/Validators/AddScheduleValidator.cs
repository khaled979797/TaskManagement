using FluentValidation;
using TaskManagement.Core.Features.Schedules.Commands.Models;

namespace TaskManagement.Core.Features.Schedules.Commands.Validators
{
    public class AddScheduleValidator : AbstractValidator<AddScheduleCommand>
    {
        public AddScheduleValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message should not be empty")
                .NotNull().WithMessage("Message should not be null");

            RuleFor(x => x.NotifyDate)
                .LessThanOrEqualTo(DateTime.Now)
                .NotEmpty().WithMessage("NotifyDate should not be empty")
                .NotNull().WithMessage("NotifyDate should not be null");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId should be greater than zero")
                .NotEmpty().WithMessage("UserId should not be empty")
                .NotNull().WithMessage("UserId should not be null");
        }
    }
}

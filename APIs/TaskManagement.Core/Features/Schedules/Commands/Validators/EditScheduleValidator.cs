using FluentValidation;
using TaskManagement.Core.Features.Schedules.Commands.Models;

namespace TaskManagement.Core.Features.Schedules.Commands.Validators
{
    public class EditScheduleValidator : AbstractValidator<EditScheduleCommand>
    {
        public EditScheduleValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id should be greater than zero")
                .NotEmpty().WithMessage("Id should not be empty")
                .NotNull().WithMessage("Id should not be null");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message should not be empty")
                .NotNull().WithMessage("Message should not be null");

            RuleFor(x => x.NotifyDate)
                .GreaterThanOrEqualTo(DateTime.Now)
                .NotEmpty().WithMessage("NotifyDate should not be empty")
                .NotNull().WithMessage("NotifyDate should not be null");
        }
    }
}

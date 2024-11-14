using FluentValidation;
using TaskManagement.Core.Features.Comments.Commands.Models;

namespace TaskManagement.Core.Features.Comments.Commands.Validators
{
    public class AddCommentValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content should not be empty")
                .NotNull().WithMessage("Content should not be null");

            RuleFor(x => x.TimeStamp)
                .NotEmpty().WithMessage("TimeStamp should not be empty")
                .NotNull().WithMessage("TimeStamp should not be null");

            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .NotEmpty().WithMessage("AppUserId should not be empty")
                .NotNull().WithMessage("AppUserId should not be null");

            RuleFor(x => x.AssignmentId)
                .GreaterThan(0)
                .NotEmpty().WithMessage("AssignmentId should not be empty")
                .NotNull().WithMessage("AssignmentId should not be null");
        }
    }
}

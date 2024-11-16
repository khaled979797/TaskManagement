﻿using FluentValidation;
using TaskManagement.Core.Features.Attachments.Commands.Models;

namespace TaskManagement.Core.Features.Attachments.Commands.Validators
{
    public class AddAttachmentValidator : AbstractValidator<AddAttachmentCommand>
    {
        public AddAttachmentValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId should be greater than zero")
                .NotEmpty().WithMessage("UserId should not be empty")
                .NotNull().WithMessage("UserId should not be null");

            RuleFor(x => x.AssignmentId)
                .GreaterThan(0).WithMessage("AssignmentId should be greater than zero")
                .NotEmpty().WithMessage("AssignmentId should not be empty")
                .NotNull().WithMessage("AssignmentId should not be null");

            RuleFor(x => x.File)
                .NotEmpty().WithMessage("File should not be empty")
                .NotNull().WithMessage("File should not be null");
        }
    }
}

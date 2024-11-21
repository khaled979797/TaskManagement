using FluentValidation;
using TaskManagement.Core.Features.Assignments.Commands.Models;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Assignments.Commands.Validators
{
    public class EditAssignmentValidator : AbstractValidator<EditAssignmentCommand>
    {
        private readonly IAssignmentRepository assignmentRepository;

        public EditAssignmentValidator(IAssignmentRepository assignmentRepository)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            this.assignmentRepository = assignmentRepository;
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id should be greater than zero")
                .NotEmpty().WithMessage("Id should not be empty")
                .NotNull().WithMessage("Id should not be null");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title should not be empty")
                .NotNull().WithMessage("Title should not be null");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description should not be empty")
                .NotNull().WithMessage("Description should not be null");

            RuleFor(x => x.Priority)
                .NotEmpty().WithMessage("Priority should not be empty")
                .NotNull().WithMessage("Priority should not be null");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status should not be empty")
                .NotNull().WithMessage("Status should not be null");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId should be greater than zero")
                .NotEmpty().WithMessage("UserId should not be empty")
                .NotNull().WithMessage("UserId should not be null");

            RuleFor(x => x.ProjectId)
                .GreaterThan(0).WithMessage("ProjectId should be greater than zero")
                .NotEmpty().WithMessage("ProjectId should not be empty")
                .NotNull().WithMessage("ProjectId should not be null");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Title)
                .MustAsync(async (model, Key, CancellationToken) => !await assignmentRepository.IsTitleExistExcludeSelf(Key!, model.Id))
                .WithMessage("Name is already exist");
        }
    }
}

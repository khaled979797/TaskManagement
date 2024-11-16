using FluentValidation;
using TaskManagement.Core.Features.Projects.Commands.Models;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Projects.Commands.Validators
{
    public class EditProjectValidator : AbstractValidator<EditProjectCommand>
    {
        private readonly IProjectRepository projectRepository;

        public EditProjectValidator(IProjectRepository projectRepository)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            this.projectRepository = projectRepository;
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id should be greater than zero")
                .NotEmpty().WithMessage("Name should not be empty")
                .NotNull().WithMessage("Name should not be null");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .NotNull().WithMessage("Name should not be null");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description should not be empty")
                .NotNull().WithMessage("Description should not be null");

            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(DateTime.Now)
                .NotEmpty().WithMessage("StartDate should not be empty")
                .NotNull().WithMessage("StartDate should not be null");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("EndDate should not be empty")
                .NotNull().WithMessage("EndDate should not be null");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, Key, CancellationToken) => !await projectRepository.IsNameExistExcludeSelf(Key, model.Id))
                .WithMessage("Name is already exist");
        }
    }
}

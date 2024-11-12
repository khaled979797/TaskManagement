using FluentValidation;
using TaskManagement.Core.Features.Projects.Commands.Models;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Projects.Commands.Validators
{
    public class AddProjectValidator : AbstractValidator<AddProjectCommand>
    {
        private readonly IProjectRepository projectRepository;

        public AddProjectValidator(IProjectRepository projectRepository)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            this.projectRepository = projectRepository;
        }

        public void ApplyValidationsRules()
        {
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
                .MustAsync(async (Key, CancellationToken) => !await projectRepository.IsNameExist(Key))
                .WithMessage("Name is already exist");
        }
    }
}

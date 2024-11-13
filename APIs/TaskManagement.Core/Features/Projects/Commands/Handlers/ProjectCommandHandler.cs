using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Projects.Commands.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Models;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Projects.Commands.Handlers
{
    public class ProjectCommandHandler : ResponseHandler,
        IRequestHandler<AddProjectCommand, NewResponse<string>>,
        IRequestHandler<EditProjectCommand, NewResponse<string>>,
        IRequestHandler<DeleteProjectCommand, NewResponse<string>>
    {
        private readonly IProjectRepository projectRepository;
        private readonly IMapper mapper;

        public ProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        public async Task<NewResponse<string>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var projectMapper = mapper.Map<Project>(request);
            var project = await projectRepository.AddAsync(projectMapper);

            if (project is null) return BadRequest<string>();
            return Success($"Added Project With Id = {project.Id}");
        }

        public async Task<NewResponse<string>> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            var project = mapper.Map<Project>(request);
            try
            {
                await projectRepository.UpdateAsync(project);
                return Success("");
            }
            catch
            {
                return BadRequest<string>();
            }
        }

        public async Task<NewResponse<string>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var result = await projectRepository.DeleteProjectById(request.Id);
            switch (result)
            {
                case "NotFound": return NotFound<string>();
                case "Failed": return BadRequest<string>();
                default: return Deleted<string>();
            }
        }
    }
}

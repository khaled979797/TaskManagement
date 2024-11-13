using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Projects.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Projects.Queries;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Projects.Queries.Handlers
{
    public class ProjectQueryHandler : ResponseHandler,
        IRequestHandler<GetProjectsQuery, NewResponse<List<GetProjectsResponse>>>,
        IRequestHandler<GetProjectByIdQuery, NewResponse<GetProjectByIdResponse>>
    {
        private readonly IProjectRepository projectRepository;
        private readonly IMapper mapper;

        public ProjectQueryHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }
        public async Task<NewResponse<List<GetProjectsResponse>>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await projectRepository.GetAllProjects();
            if (projects is null) return NotFound<List<GetProjectsResponse>>();

            var projectsMapper = mapper.Map<List<GetProjectsResponse>>(projects);
            return Success(projectsMapper);
        }

        public async Task<NewResponse<GetProjectByIdResponse>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await projectRepository.GetProjectById(request.Id);
            if (project is null) return NotFound<GetProjectByIdResponse>();

            var projectMapper = mapper.Map<GetProjectByIdResponse>(project);
            return Success(projectMapper);
        }
    }
}

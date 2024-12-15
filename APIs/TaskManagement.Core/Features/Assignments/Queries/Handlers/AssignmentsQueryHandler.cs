using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Assignments.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Assignments.Queries;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Assignments.Queries.Handlers
{
    public class AssignmentsQueryHandler : ResponseHandler,
        IRequestHandler<GetAssignmentsQuery, NewResponse<List<GetAssignmentsResponse>>>,
        IRequestHandler<GetAssignmentsByUserQuery, NewResponse<List<GetAssignmentsResponse>>>,
        IRequestHandler<GetAssignmentByIdQuery, NewResponse<GetAssignmentByIdResponse>>
    {
        private readonly IAssignmentRepository assignmentRepository;
        private readonly IMapper mapper;

        public AssignmentsQueryHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            this.assignmentRepository = assignmentRepository;
            this.mapper = mapper;
        }
        public async Task<NewResponse<List<GetAssignmentsResponse>>> Handle(GetAssignmentsQuery request, CancellationToken cancellationToken)
        {
            var assignments = await assignmentRepository.GetAllAssignments();
            if (assignments is null) return NotFound<List<GetAssignmentsResponse>>();
            var assignmentsMapper = mapper.Map<List<GetAssignmentsResponse>>(assignments);
            return Success(assignmentsMapper);
        }

        public async Task<NewResponse<GetAssignmentByIdResponse>> Handle(GetAssignmentByIdQuery request, CancellationToken cancellationToken)
        {
            var assignment = await assignmentRepository.GetAssignmentById(request.Id);
            if (assignment is null) return NotFound<GetAssignmentByIdResponse>();
            var assignmentMapper = mapper.Map<GetAssignmentByIdResponse>(assignment);
            return Success(assignmentMapper);
        }

        public async Task<NewResponse<List<GetAssignmentsResponse>>> Handle(GetAssignmentsByUserQuery request, CancellationToken cancellationToken)
        {
            var assignments = await assignmentRepository.GetAllAssignmentsByUser(request.Id);
            if (assignments is null) return NotFound<List<GetAssignmentsResponse>>();
            var assignmentsMapper = mapper.Map<List<GetAssignmentsResponse>>(assignments);
            return Success(assignmentsMapper);
        }
    }
}

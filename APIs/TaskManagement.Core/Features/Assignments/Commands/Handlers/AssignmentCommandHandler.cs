using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Assignments.Commands.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Models;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Assignments.Commands.Handlers
{
    public class AssignmentCommandHandler : ResponseHandler,
        IRequestHandler<AddAssignmentCommand, NewResponse<string>>,
        IRequestHandler<EditAssignmentCommand, NewResponse<string>>,
        IRequestHandler<DeleteAssignmentCommand, NewResponse<string>>
    {
        private readonly IAssignmentRepository assignmentRepository;
        private readonly IMapper mapper;

        public AssignmentCommandHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            this.assignmentRepository = assignmentRepository;
            this.mapper = mapper;
        }
        public async Task<NewResponse<string>> Handle(AddAssignmentCommand request, CancellationToken cancellationToken)
        {
            var assignmentMapper = mapper.Map<Assignment>(request);
            var assignment = await assignmentRepository.AddAssignment(assignmentMapper);
            if (assignment is null) return BadRequest<string>();
            return Created($"Assignment Created With Id: {assignment.Id}");
        }

        public async Task<NewResponse<string>> Handle(EditAssignmentCommand request, CancellationToken cancellationToken)
        {
            var assignmentMapper = mapper.Map<Assignment>(request);
            var result = await assignmentRepository.EditAssignment(assignmentMapper);

            switch (result)
            {
                case "NotFound": return NotFound<string>("NotFound");
                case "UserNotFound": return NotFound<string>("UserNotFound");
                case "ProjectNotFound": return NotFound<string>("ProjectNotFound");
                case "Failed": return BadRequest<string>("Failed");
                default: return Success("");
            }
        }

        public async Task<NewResponse<string>> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
        {
            var result = await assignmentRepository.DeleteAssignmentById(request.Id);
            switch (result)
            {
                case "NotFound": return NotFound<string>("NotFound");
                case "Failed": return BadRequest<string>("Failed");
                default: return Deleted<string>();
            }
        }
    }
}

using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Models;

namespace TaskManagement.Core.Features.Assignments.Commands.Models
{
    public class CompleteAssignmentCommand : IRequest<NewResponse<Assignment>>
    {
        public int Id { get; set; }
        public CompleteAssignmentCommand(int id)
        {
            Id = id;
        }
    }
}

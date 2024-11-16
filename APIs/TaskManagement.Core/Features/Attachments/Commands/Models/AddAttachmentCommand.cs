using MediatR;
using Microsoft.AspNetCore.Http;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Attachments.Commands.Models
{
    public class AddAttachmentCommand : IRequest<NewResponse<string>>
    {
        public IFormFile? File { get; set; }
        public int UserId { get; set; }
        public int AssignmentId { get; set; }
    }
}

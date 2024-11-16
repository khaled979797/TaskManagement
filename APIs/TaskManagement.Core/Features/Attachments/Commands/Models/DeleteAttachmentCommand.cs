using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Attachments.Commands.Models
{
    public class DeleteAttachmentCommand : IRequest<NewResponse<string>>
    {
        public int Id { get; set; }
        public DeleteAttachmentCommand(int id)
        {
            Id = id;
        }
    }
}

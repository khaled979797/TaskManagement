using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Attachments.Queries;

namespace TaskManagement.Core.Features.Attachments.Queries.Models
{
    public class GetAttachmentByIdQuery : IRequest<NewResponse<GetAttachmentByIdResponse>>
    {
        public int Id { get; set; }
        public GetAttachmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}

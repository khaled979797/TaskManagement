using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Notifications.Queries;

namespace TaskManagement.Core.Features.Notifications.Queries.Models
{
    public class GetNotificationByIdQuery : IRequest<NewResponse<GetNotificationByIdResponse>>
    {
        public int Id { get; set; }
        public GetNotificationByIdQuery(int id)
        {
            Id = id;
        }
    }
}

using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Notifications.Queries;

namespace TaskManagement.Core.Features.Notifications.Queries.Models
{
    public class GetNotificationsQuery : IRequest<NewResponse<List<GetNotificationsResponse>>>
    {
        public int UserId { get; set; }
        public GetNotificationsQuery(int userId)
        {
            UserId = userId;
        }
    }
}

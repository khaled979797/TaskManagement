using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Schedules.Queries;

namespace TaskManagement.Core.Features.Schedules.Queries.Models
{
    public class GetSchedulesForUserQuery : IRequest<NewResponse<List<GetSchedulesForUserResponse>>>
    {
        public int UserId { get; set; }
        public GetSchedulesForUserQuery(int userId)
        {
            UserId = userId;
        }
    }
}

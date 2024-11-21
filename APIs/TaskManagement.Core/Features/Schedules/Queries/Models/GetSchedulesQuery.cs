using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Schedules.Queries;

namespace TaskManagement.Core.Features.Schedules.Queries.Models
{
    public class GetSchedulesQuery : IRequest<NewResponse<List<GetSchedulesResponse>>>
    {
    }
}

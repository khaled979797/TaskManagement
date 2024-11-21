using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Schedules.Queries;

namespace TaskManagement.Core.Features.Schedules.Queries.Models
{
    public class GetScheduleByIdQuery : IRequest<NewResponse<GetScheduleByIdResponse>>
    {
        public int Id { get; set; }
        public GetScheduleByIdQuery(int id)
        {
            Id = id;
        }
    }
}

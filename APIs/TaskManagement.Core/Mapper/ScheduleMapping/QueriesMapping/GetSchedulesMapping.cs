using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Schedules.Queries;

namespace TaskManagement.Core.Mapper.ScheduleMapping
{
    public partial class ScheduleMappingProfile
    {
        public void GetSchedulesMapping()
        {
            CreateMap<Schedule, GetSchedulesResponse>()
                .ForPath(dst => dst.UserName, opt => opt.MapFrom(src => src.User!.UserName));
        }
    }
}

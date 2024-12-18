using TaskManagement.Core.Features.Schedules.Commands.Models;
using TaskManagement.Data.Models;

namespace TaskManagement.Core.Mapper.ScheduleMapping
{
    public partial class ScheduleMappingProfile
    {
        public void EditScheduleMapping()
        {
            CreateMap<EditScheduleCommand, Schedule>();
        }
    }
}

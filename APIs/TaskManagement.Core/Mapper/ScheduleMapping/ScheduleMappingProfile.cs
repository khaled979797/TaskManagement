using AutoMapper;

namespace TaskManagement.Core.Mapper.ScheduleMapping
{
    public partial class ScheduleMappingProfile : Profile
    {
        public ScheduleMappingProfile()
        {
            #region Commands
            AddScheduleMapping();
            #endregion

            #region Queries
            GetSchedulesMapping();
            GetSchedulesForUserMapping();
            GetScheduleByIdMapping();
            #endregion
        }
    }
}

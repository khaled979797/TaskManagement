using TaskManagement.Core.Features.Assignments.Commands.Models;
using TaskManagement.Data.Models;

namespace TaskManagement.Core.Mapper.AssignmentMapping
{
    public partial class AssignmentMappingProfile
    {
        public void EditAssignmentMapping()
        {
            CreateMap<EditAssignmentCommand, Assignment>()
                .ForMember(dst => dst.AppUserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}

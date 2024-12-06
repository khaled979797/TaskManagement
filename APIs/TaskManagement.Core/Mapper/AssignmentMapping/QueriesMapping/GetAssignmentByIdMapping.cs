using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Assignments.Queries;

namespace TaskManagement.Core.Mapper.AssignmentMapping
{
    public partial class AssignmentMappingProfile
    {
        public void GetAssignmentByIdMapping()
        {
            CreateMap<Assignment, GetAssignmentByIdResponse>()
                .ForMember(dst => dst.Priority, opt => opt.MapFrom(src => src.Priority.ToString()))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForPath(dst => dst.UserName, opt => opt.MapFrom(src => src.User!.UserName))
                .ForPath(dst => dst.AssignmentComments, opt => opt.MapFrom(src => src.Comments))
                .ForPath(dst => dst.AssignmentAttachments, opt => opt.MapFrom(src => src.Attachments));

            CreateMap<Comment, AssignmentComment>()
                .ForPath(dst => dst.CommentedByUser, opt => opt.MapFrom(src => src.User!.UserName));

            CreateMap<Attachment, AssignmentAttachment>()
                .ForPath(dst => dst.AddedByUser, opt => opt.MapFrom(src => src.User!.UserName));
        }
    }
}

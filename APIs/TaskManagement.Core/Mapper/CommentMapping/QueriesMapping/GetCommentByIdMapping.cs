using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Comments.Queries;

namespace TaskManagement.Core.Mapper.CommentMapping
{
    public partial class CommentMappingProfile
    {
        public void GetCommentByIdMapping()
        {
            CreateMap<Comment, GetCommentsResponse>()
                .ForPath(dst => dst.UserName, opt => opt.MapFrom(src => src.User!.UserName));
        }
    }
}

using TaskManagement.Core.Features.Comments.Commands.Models;
using TaskManagement.Data.Models;

namespace TaskManagement.Core.Mapper.CommentMapping
{
    public partial class CommentMappingProfile
    {
        public void AddCommentMapping()
        {
            CreateMap<AddCommentCommand, Comment>();
        }
    }
}

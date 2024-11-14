using AutoMapper;

namespace TaskManagement.Core.Mapper.CommentMapping
{
    public partial class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            #region Commands
            AddCommentMapping();
            EditCommentMapping();
            #endregion

            #region Queries
            GetCommentsMapping();
            GetCommentByIdMapping();
            #endregion
        }
    }
}

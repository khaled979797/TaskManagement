﻿using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Comments.Queries;

namespace TaskManagement.Core.Mapper.CommentMapping
{
    public partial class CommentMappingProfile
    {
        public void GetCommentsMapping()
        {
            CreateMap<Comment, GetCommentByIdResponse>()
                .ForPath(dst => dst.UserName, opt => opt.MapFrom(src => src.User!.UserName));
        }
    }
}
﻿using MediatR;
using TaskManagement.Core.Helpers;

namespace TaskManagement.Core.Features.Comments.Commands.Models
{
    public class AddCommentCommand : IRequest<NewResponse<string>>
    {
        public string? Content { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int AssignmentId { get; set; }
    }
}
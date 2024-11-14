using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Features.Comments.Commands.Models;
using TaskManagement.Core.Features.Comments.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Helpers.Meta;
using TaskManagement.Data.Responses.Comments.Queries;

namespace TaskManagement.Api.Controllers
{
    public class CommentController : AppControllerBase
    {
        #region Commands
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpPost(Router.CommentRouting.AddComment)]
        public async Task<IActionResult> AddComment(AddCommentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpPut(Router.CommentRouting.EditComment)]
        public async Task<IActionResult> EditComment(EditCommentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpDelete(Router.CommentRouting.DeleteCommentById)]
        public async Task<IActionResult> DeleteCommentById(int id)
        {
            var response = await Mediator.Send(new DeleteCommentCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Queries
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<List<GetCommentsResponse>>))]
        [HttpGet(Router.CommentRouting.GetAllComments)]
        public async Task<IActionResult> GetAllComments(int assignmentId)
        {
            var response = await Mediator.Send(new GetCommentsQuery(assignmentId));
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<GetCommentByIdResponse>))]
        [HttpGet(Router.CommentRouting.GetCommentById)]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var response = await Mediator.Send(new GetCommentByIdQuery(id));
            return NewResult(response);
        }
        #endregion
    }
}

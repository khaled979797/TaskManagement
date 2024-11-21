using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Features.Attachments.Commands.Models;
using TaskManagement.Core.Features.Attachments.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Helpers.Meta;
using TaskManagement.Data.Responses.Attachments.Queries;

namespace TaskManagement.Api.Controllers
{
    public class AttachmentController : AppControllerBase
    {
        #region Commands
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NewResponse<string>))]
        [HttpPost(Router.AttachmentRouting.AddAttachment)]
        public async Task<IActionResult> AddAttachment(AddAttachmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpDelete(Router.AttachmentRouting.DeleteAttachmentById)]
        public async Task<IActionResult> DeleteAttachmentById(int id)
        {
            var response = await Mediator.Send(new DeleteAttachmentCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Queries
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<List<GetAttachmentsResponse>>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<List<GetAttachmentsResponse>>))]
        [HttpGet(Router.AttachmentRouting.GetAllAttachments)]
        public async Task<IActionResult> GetAllAttachments()
        {
            var response = await Mediator.Send(new GetAttachmentsQuery());
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<GetAttachmentByIdResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<GetAttachmentByIdResponse>))]
        [HttpGet(Router.AttachmentRouting.GetAttachmentById)]
        public async Task<IActionResult> GetAttachmentById(int id)
        {
            var response = await Mediator.Send(new GetAttachmentByIdQuery(id));
            return NewResult(response);
        }
        #endregion
    }
}

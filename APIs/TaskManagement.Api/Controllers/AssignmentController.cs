using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Features.Assignments.Commands.Models;
using TaskManagement.Core.Features.Assignments.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Helpers.Meta;
using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Assignments.Queries;

namespace TaskManagement.Api.Controllers
{
    public class AssignmentController : AppControllerBase
    {
        #region Commands
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NewResponse<string>))]
        [HttpPost(Router.AssignmentRouting.AddAssignment)]
        public async Task<IActionResult> AddAssignment(AddAssignmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpPut(Router.AssignmentRouting.EditAssignment)]
        public async Task<IActionResult> EditAssignment(EditAssignmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpDelete(Router.AssignmentRouting.DeleteAssignmentById)]
        public async Task<IActionResult> DeleteAssignmentById(int id)
        {
            var response = await Mediator.Send(new DeleteAssignmentCommand(id));
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<Assignment>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<Assignment>))]
        [HttpPatch(Router.AssignmentRouting.MarkAssignmentCompleted)]
        public async Task<IActionResult> MarkAssignmentCompleted(int id)
        {
            var response = await Mediator.Send(new CompleteAssignmentCommand(id));
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<Assignment>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<Assignment>))]
        [HttpPatch(Router.AssignmentRouting.MarkAssignmentUncompleted)]
        public async Task<IActionResult> MarkAssignmentUncompleted(int id)
        {
            var response = await Mediator.Send(new UncompleteAssignmentCommand(id));
            return NewResult(response);
        }

        #endregion

        #region Queries
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<List<GetAssignmentsResponse>>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<List<GetAssignmentsResponse>>))]
        [HttpGet(Router.AssignmentRouting.GetAllAssignments)]
        public async Task<IActionResult> GetAllAssignments()
        {
            var response = await Mediator.Send(new GetAssignmentsQuery());
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<GetAssignmentByIdResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<GetAssignmentByIdResponse>))]
        [HttpGet(Router.AssignmentRouting.GetAssignmentById)]
        public async Task<IActionResult> GetAssignmentById(int id)
        {
            var response = await Mediator.Send(new GetAssignmentByIdQuery(id));
            return NewResult(response);
        }
        #endregion
    }
}

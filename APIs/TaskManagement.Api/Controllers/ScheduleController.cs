using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Features.Schedules.Commands.Models;
using TaskManagement.Core.Features.Schedules.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Helpers.Meta;
using TaskManagement.Data.Responses.Schedules.Queries;

namespace TaskManagement.Api.Controllers
{
    public class ScheduleController : AppControllerBase
    {
        #region Commands
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NewResponse<string>))]
        [HttpPost(Router.ScheduleRouting.AddSchedule)]
        public async Task<IActionResult> AddSchedule(AddScheduleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpPut(Router.ScheduleRouting.EditSchedule)]
        public async Task<IActionResult> EditSchedule(EditScheduleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpDelete(Router.ScheduleRouting.DeleteScheduleById)]
        public async Task<IActionResult> DeleteScheduleById(int id)
        {
            var response = await Mediator.Send(new DeleteScheduleCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Queries
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<List<GetSchedulesResponse>>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<List<GetSchedulesResponse>>))]
        [HttpGet(Router.ScheduleRouting.GetAllSchedules)]
        public async Task<IActionResult> GetAllSchedules()
        {
            var response = await Mediator.Send(new GetSchedulesQuery());
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<List<GetSchedulesForUserResponse>>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<List<GetSchedulesForUserResponse>>))]
        [HttpGet(Router.ScheduleRouting.GetAllSchedulesForUser)]
        public async Task<IActionResult> GetAllSchedules(int userId)
        {
            var response = await Mediator.Send(new GetSchedulesForUserQuery(userId));
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<GetScheduleByIdResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<GetScheduleByIdResponse>))]
        [HttpGet(Router.ScheduleRouting.GetScheduleById)]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            var response = await Mediator.Send(new GetScheduleByIdQuery(id));
            return NewResult(response);
        }
        #endregion
    }
}

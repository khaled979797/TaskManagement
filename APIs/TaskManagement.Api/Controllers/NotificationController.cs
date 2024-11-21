using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Features.Notifications.Commands.Models;
using TaskManagement.Core.Features.Notifications.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Helpers.Meta;
using TaskManagement.Data.Responses.Notifications.Commands;
using TaskManagement.Data.Responses.Notifications.Queries;

namespace TaskManagement.Api.Controllers
{
    public class NotificationController : AppControllerBase
    {
        #region Commands
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NewResponse<string>))]
        [HttpPost(Router.NotificationRouting.AddNotification)]
        public async Task<IActionResult> AddNotification(AddNotificationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpDelete(Router.NotificationRouting.DeleteAllNotifications)]
        public async Task<IActionResult> DeleteAllNotifications(int userId)
        {
            var response = await Mediator.Send(new DeleteAllNotificationsCommand(userId));
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<string>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpDelete(Router.NotificationRouting.DeleteNotificationById)]
        public async Task<IActionResult> DeleteNotificationById(int id)
        {
            var response = await Mediator.Send(new DeleteNotificationByIdCommand(id));
            return NewResult(response);
        }


        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<List<ReadAllNotificationsResponse>>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<List<ReadAllNotificationsResponse>>))]
        [HttpPut(Router.NotificationRouting.ReadAllNotifications)]
        public async Task<IActionResult> ReadAllNotifications(int userId)
        {
            var response = await Mediator.Send(new ReadAllNotificationsCommand(userId));
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<ReadNotificationByIdResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<ReadNotificationByIdResponse>))]
        [HttpPut(Router.NotificationRouting.ReadNotificationById)]
        public async Task<IActionResult> ReadNotificationById(int id)
        {
            var response = await Mediator.Send(new ReadNotificationByIdCommand(id));
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<List<UnreadAllNotificationsResponse>>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<List<UnreadAllNotificationsResponse>>))]
        [HttpPut(Router.NotificationRouting.UnreadAllNotifications)]
        public async Task<IActionResult> UnreadAllNotifications(int userId)
        {
            var response = await Mediator.Send(new UnreadAllNotificationsCommand(userId));
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NewResponse<UnreadNotificationByIdResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<UnreadNotificationByIdResponse>))]
        [HttpPut(Router.NotificationRouting.UnreadNotificationById)]
        public async Task<IActionResult> UnreadNotificationById(int id)
        {
            var response = await Mediator.Send(new UnreadNotificationByIdCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Queries
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<List<GetNotificationsResponse>>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<List<GetNotificationsResponse>>))]
        [HttpGet(Router.NotificationRouting.GetAllNotifications)]
        public async Task<IActionResult> GetAllNotifications(int userId)
        {
            var response = await Mediator.Send(new GetNotificationsQuery(userId));
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NewResponse<GetNotificationByIdResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<GetNotificationByIdResponse>))]
        [HttpGet(Router.NotificationRouting.GetNotificationById)]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var response = await Mediator.Send(new GetNotificationByIdQuery(id));
            return NewResult(response);
        }
        #endregion
    }
}

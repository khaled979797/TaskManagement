using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Features.Users.Commands.Models;
using TaskManagement.Core.Features.Users.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Helpers.Meta;
using TaskManagement.Data.Responses.Users.Commands;
using TaskManagement.Data.Responses.Users.Queries;
namespace TaskManagement.Api.Controllers
{
    public class UserController : AppControllerBase
    {
        #region Commands
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NewResponse<RegisterUserResponse>))]
        [HttpPost(Router.UserRouting.Register)]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<LoginUserResponse>))]
        [HttpPost(Router.UserRouting.Login)]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpPut(Router.UserRouting.EditUser)]
        public async Task<IActionResult> EditUser(EditUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<string>))]
        [HttpDelete(Router.UserRouting.DeleteUserById)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Queries
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<List<GetUsersResponse>>))]
        [HttpGet(Router.UserRouting.GetAllUsers)]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await Mediator.Send(new GetUsersQuery());
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponse<GetUserByIdResponse>))]
        [HttpGet(Router.UserRouting.GetUserById)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }
        #endregion
    }
}

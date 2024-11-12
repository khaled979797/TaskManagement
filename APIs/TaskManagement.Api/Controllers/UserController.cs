using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Features.Users.Commands.Models;
using TaskManagement.Core.Features.Users.Queries.Models;
using TaskManagement.Data.Helpers.Meta;
namespace TaskManagement.Api.Controllers
{
    public class UserController : AppControllerBase
    {
        #region Commands
        [HttpPost(Router.UserRouting.Register)]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost(Router.UserRouting.Login)]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.UserRouting.EditUser)]
        public async Task<IActionResult> EditUser(EditUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.UserRouting.DeleteUser)]
        public async Task<IActionResult> DeleteUser([FromRoute] string username)
        {
            var response = await Mediator.Send(new DeleteUserCommand(username));
            return NewResult(response);
        }
        #endregion

        #region Queries
        [HttpGet(Router.UserRouting.GetAllUsers)]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await Mediator.Send(new GetUsersQuery());
            return NewResult(response);
        }

        [HttpGet(Router.UserRouting.GetUserById)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }

        [HttpGet(Router.UserRouting.GetUserByUsername)]
        public async Task<IActionResult> GetUserById([FromRoute] string username)
        {
            var response = await Mediator.Send(new GetUserByUsernameQuery(username));
            return NewResult(response);
        }
        #endregion
    }
}

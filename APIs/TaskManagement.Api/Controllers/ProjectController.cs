using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Features.Projects.Commands.Models;
using TaskManagement.Core.Features.Projects.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Helpers.Meta;
using TaskManagement.Data.Responses.Projects.Queries;

namespace TaskManagement.Api.Controllers
{
    public class ProjectController : AppControllerBase
    {
        #region Commands
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NewResponse<string>))]
        [HttpPost(Router.ProjectRouting.AddProject)]
        public async Task<IActionResult> AddProject(AddProjectCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NewResponse<string>))]
        [HttpPut(Router.ProjectRouting.EditProject)]
        public async Task<IActionResult> EditProject(EditProjectCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NewResponse<string>))]
        [HttpDelete(Router.ProjectRouting.DeleteProjectById)]
        public async Task<IActionResult> DeleteProjectById(int id)
        {
            var response = await Mediator.Send(new DeleteProjectCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Queries
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NewResponse<List<GetProjectsResponse>>))]
        [HttpGet(Router.ProjectRouting.GetAllProjects)]
        public async Task<IActionResult> GetAllProjects()
        {
            var response = await Mediator.Send(new GetProjectsQuery());
            return NewResult(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NewResponse<GetProjectByIdResponse>))]
        [HttpGet(Router.ProjectRouting.GetProjectById)]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var response = await Mediator.Send(new GetProjectByIdQuery(id));
            return NewResult(response);
        }
        #endregion
    }
}

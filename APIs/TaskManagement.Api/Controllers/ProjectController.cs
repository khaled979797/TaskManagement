using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Features.Projects.Commands.Models;
using TaskManagement.Core.Features.Projects.Queries.Models;
using TaskManagement.Data.Helpers.Meta;

namespace TaskManagement.Api.Controllers
{
    public class ProjectController : AppControllerBase
    {
        #region Commands
        [HttpPost(Router.ProjectRouting.AddProject)]
        public async Task<IActionResult> AddProject(AddProjectCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.ProjectRouting.EditProject)]
        public async Task<IActionResult> EditProject(EditProjectCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.ProjectRouting.DeleteProjectById)]
        public async Task<IActionResult> DeleteProjectById(int id)
        {
            var response = await Mediator.Send(new DeleteProjectByIdCommand(id));
            return NewResult(response);
        }

        [HttpDelete(Router.ProjectRouting.DeleteProjectByName)]
        public async Task<IActionResult> DeleteProjectByName(string name)
        {
            var response = await Mediator.Send(new DeleteProjectByNameCommand(name));
            return NewResult(response);
        }
        #endregion

        #region Queries
        [HttpGet(Router.ProjectRouting.GetAllProjects)]
        public async Task<IActionResult> GetAllProjects()
        {
            var response = await Mediator.Send(new GetProjectsQuery());
            return NewResult(response);
        }

        [HttpGet(Router.ProjectRouting.GetProjectById)]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var response = await Mediator.Send(new GetProjectByIdQuery(id));
            return NewResult(response);
        }

        [HttpGet(Router.ProjectRouting.GetProjectByName)]
        public async Task<IActionResult> GetProjectByName([FromRoute] string name)
        {
            var response = await Mediator.Send(new GetProjectByNameQuery(name));
            return NewResult(response);
        }
        #endregion
    }
}

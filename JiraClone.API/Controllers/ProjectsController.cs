using JiraClone.Application.Features.Projects.Commands.CreateProject;
using JiraClone.Application.Features.Projects.Commands.DeleteProject;
using JiraClone.Application.Features.Projects.Commands.UpdateProject;
using JiraClone.Application.Features.Projects.Queries.GetAllProjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JiraClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        {
            var projectId = await _mediator.Send(command);

            return Ok(projectId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _mediator.Send(new GetAllProjectsQuery());
            return Ok(projects);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProjectCommand command)
        {

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteProjectCommand(id));

            return NoContent();
        }
    
    }
}

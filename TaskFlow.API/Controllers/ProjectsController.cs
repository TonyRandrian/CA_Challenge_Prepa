using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.Contracts.Requests;
using TaskFlow.Application.Commands.CreateProject;
using TaskFlow.Application.Commands.RenameProject;
using TaskFlow.Application.Queries.GetProjectById;
using TaskFlow.Domain.Entities;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        {
            Guid projectId = await _sender.Send(command);

            return Created(
                $"/api/projects/{projectId}",
                projectId);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            Project? project = await _sender.Send(new GetProjectByIdQuery(id));

            if (project is null)
                return NotFound();

            return Ok(project);
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult> Rename(
            [FromRoute] Guid id,
            [FromBody] RenameProjectRequest request)
        {
            await _sender.Send(new RenameProjectCommand(id, request.Name));
            return NoContent();
        }
    }
}

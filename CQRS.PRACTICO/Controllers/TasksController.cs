using CQRS.PRACTICO.Application.DTOs;
using CQRS.PRACTICO.Domain;
using CQRS.PRACTICO.Infrastructure.Commands;
using CQRS.PRACTICO.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRS.PRACTICO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItemDto>> GetAll()
        {
            return await _mediator.Send(new GetAllTasksQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetById(int id)
        {
            var query = new GetTaskByIdQuery(id);
            var taskItem = await _mediator.Send(query);
            if (taskItem == null) { 
                return NotFound();
            }
            return taskItem;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> Create(CreateTaskCommand command)
        {
            var taskItem = _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = taskItem.Id }, taskItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskItemDto>> Update(int id, UpdateTaskCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            var taskItem = await _mediator.Send(command);

            if (taskItem == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskItemDto>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteTaskCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

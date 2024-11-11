using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taskeroni.Application.Commands;
using Taskeroni.Application.Queries;

namespace Taskeroni.API.Controllers
{
    [ApiController]
    [Route("api/todotasks")]
    public class TodoTasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoTasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoTask([FromBody] CreateTaskCommand command)
        {
            if (command == null || string.IsNullOrWhiteSpace(command.Title))
                return BadRequest("Task title is required.");

            var taskId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTodoTaskById), new { id = taskId }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoTaskById(Guid id)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery { Id = id });
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingTasks()
        {
            var tasks = await _mediator.Send(new GetPendingTasksQuery());
            return Ok(tasks);
        }

        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdueTasks()
        {
            var tasks = await _mediator.Send(new GetOverdueTasksQuery());
            return Ok(tasks);
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> MarkTaskAsCompleted(Guid id)
        {
            var result = await _mediator.Send(new MarkTaskAsCompletedCommand { Id = id });
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoTask(Guid id, [FromBody] UpdateTaskCommand command)
        {
            if (command == null || string.IsNullOrWhiteSpace(command.Title))
                return BadRequest("Task title is required.");

            command.Id = id;
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoTask(Guid id)
        {
            var result = await _mediator.Send(new DeleteTaskCommand { Id = id });
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompletedTasks()
        {
            var tasks = await _mediator.Send(new GetCompletedTasksQuery());
            return Ok(tasks);
        }
    }
}

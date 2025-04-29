using CurotecTaskBackApi.Commands;
using CurotecTaskBackApi.Handlers;
using CurotecTaskBackApi.Models;
using CurotecTaskBackApi.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using CurotecTaskBackApi.Hubs;

namespace CurotecTaskBackApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly CreateTaskHandler _createTaskHandler;
        private readonly UpdateTaskHandler _updateTaskHandler;
        private readonly DeleteTaskHandler _deleteTaskHandler;
        private readonly TaskQueries _taskQueries;
        private readonly IHubContext<TaskHub> _hubContext;

        public TaskController(
            CreateTaskHandler createTaskHandler,
            UpdateTaskHandler updateTaskHandler,
            DeleteTaskHandler deleteTaskHandler,
            TaskQueries taskQueries,
            IHubContext<TaskHub> hubContext
        )
        {
            _createTaskHandler = createTaskHandler;
            _updateTaskHandler = updateTaskHandler;
            _deleteTaskHandler = deleteTaskHandler;
            _taskQueries = taskQueries;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetAllTasks()
        {
            var tasks = await _taskQueries.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            var task = await _taskQueries.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> AddTask(CreateTaskCommand command)
        {
            if (!TryValidateModel(command))
            {
                return BadRequest(ModelState);
            }

            await _createTaskHandler.Handle(command);
            await _hubContext.Clients.All.SendAsync("TaskAdded", command);
            return CreatedAtAction(nameof(GetTaskById), new { id = command.Id }, command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, UpdateTaskCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            if (!TryValidateModel(command))
            {
                return BadRequest(ModelState);
            }

            await _updateTaskHandler.Handle(command);
            await _hubContext.Clients.All.SendAsync("TaskUpdated", command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var command = new DeleteTaskCommand { Id = id };
            await _deleteTaskHandler.Handle(command);
            await _hubContext.Clients.All.SendAsync("TaskDeleted", id);
            return NoContent();
        }
    }
}

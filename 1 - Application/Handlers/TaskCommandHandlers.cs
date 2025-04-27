using CurotecTaskBackApi.Commands;
using Domain.Services;
using Microsoft.Extensions.Logging;
using TaskEntity = CurotecTaskBackApi.Entities.Task;

namespace CurotecTaskBackApi.Handlers
{
    public class CreateTaskHandler
    {
        private readonly ITaskService _service;
        private readonly ILogger<CreateTaskHandler> _logger;

        public CreateTaskHandler(ITaskService service, ILogger<CreateTaskHandler> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task Handle(CreateTaskCommand command)
        {
            try
            {
                var task = new TaskEntity { Name = command.Name, Description = command.Description };

                var createdTask = await _service.AddTaskAsync(task);
                command.Id = createdTask.Id;

                _logger.LogInformation("Task created successfully with ID: {TaskId}", createdTask.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating task");
                throw;
            }
        }
    }

    public class UpdateTaskHandler
    {
        private readonly ITaskService _service;
        private readonly ILogger<UpdateTaskHandler> _logger;

        public UpdateTaskHandler(ITaskService service, ILogger<UpdateTaskHandler> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task Handle(UpdateTaskCommand command)
        {
            try
            {
                var task = new TaskEntity
                {
                    Id = command.Id,
                    Name = command.Name,
                    Description = command.Description
                };

                await _service.UpdateTaskAsync(task);

                _logger.LogInformation("Task updated successfully with ID: {TaskId}", task.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating task with ID: {TaskId}", command.Id);
                throw;
            }
        }
    }

    public class DeleteTaskHandler
    {
        private readonly ITaskService _service;
        private readonly ILogger<DeleteTaskHandler> _logger;

        public DeleteTaskHandler(ITaskService service, ILogger<DeleteTaskHandler> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task Handle(DeleteTaskCommand command)
        {
            try
            {
                await _service.DeleteTaskAsync(command.Id);

                _logger.LogInformation("Task deleted successfully with ID: {TaskId}", command.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting task with ID: {TaskId}", command.Id);
                throw;
            }
        }
    }
}

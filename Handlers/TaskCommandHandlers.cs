using CurotecTaskBackApi.Commands;
using CurotecTaskBackApi.Services;
using TaskEntity = CurotecTaskBackApi.Entities.Task;

namespace CurotecTaskBackApi.Handlers
{
    public class CreateTaskHandler
    {
        private readonly ITaskService _service;

        public CreateTaskHandler(ITaskService service)
        {
            _service = service;
        }

        public async Task Handle(CreateTaskCommand command)
        {
            var task = new TaskEntity { Name = command.Name, Description = command.Description };

            var createdTask = await _service.AddTaskAsync(task);
            command.Id = createdTask.Id;
        }
    }

    public class UpdateTaskHandler
    {
        private readonly ITaskService _service;

        public UpdateTaskHandler(ITaskService service)
        {
            _service = service;
        }

        public async Task Handle(UpdateTaskCommand command)
        {
            var task = new TaskEntity
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description
            };

            await _service.UpdateTaskAsync(task);
        }
    }

    public class DeleteTaskHandler
    {
        private readonly ITaskService _service;

        public DeleteTaskHandler(ITaskService service)
        {
            _service = service;
        }

        public async Task Handle(DeleteTaskCommand command)
        {
            await _service.DeleteTaskAsync(command.Id);
        }
    }
}

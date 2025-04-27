using System.Threading.Tasks;
using CurotecTaskBackApi.Commands;
using CurotecTaskBackApi.Repositories;
using CurotecTaskBackApi.Entities;

namespace CurotecTaskBackApi.Handlers
{
    public class CreateTaskHandler
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task Handle(CreateTaskCommand command)
        {
            var task = new CurotecTaskBackApi.Entities.Task
            {
                Title = command.Title,
                Description = command.Description,
                Status = command.Status,
                CreatedDate = command.CreatedDate
            };

            await _taskRepository.AddTaskAsync(task);
        }
    }

    public class UpdateTaskHandler
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateTaskCommand command)
        {
            var task = new CurotecTaskBackApi.Entities.Task
            {
                Id = command.Id,
                Title = command.Title,
                Description = command.Description,
                Status = command.Status
            };

            await _taskRepository.UpdateTaskAsync(task);
        }
    }

    public class DeleteTaskHandler
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task Handle(DeleteTaskCommand command)
        {
            await _taskRepository.DeleteTaskAsync(command.Id);
        }
    }
}

using CurotecTaskBackApi.Entities;
using CurotecTaskBackApi.Queries;
using CurotecTaskBackApi.Repositories;

namespace CurotecTaskBackApi.Handlers
{
    public class GetAllTasksHandler
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTasksHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Entities.Task>> Handle(GetAllTasksQuery query)
        {
            return await _taskRepository.GetAllTasksAsync();
        }
    }

    public class GetTaskByIdHandler
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskByIdHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Entities.Task> Handle(GetTaskByIdQuery query)
        {
            return await _taskRepository.GetTaskByIdAsync(query.Id);
        }
    }
}

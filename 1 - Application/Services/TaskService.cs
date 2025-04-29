using CurotecTaskBackApi.Repositories;
using Domain.Services;

namespace CurotecTaskBackApi.Services
{

    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Entities.Task>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<Entities.Task> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }

        public async Task<Entities.Task> AddTaskAsync(Entities.Task task)
        {
            var addedTask = await _taskRepository.AddTaskAsync(task);
            return addedTask;
        }

        public async Task<Entities.Task> UpdateTaskAsync(Entities.Task task)
        {
            var updatedTask = await _taskRepository.UpdateTaskAsync(task);
            return updatedTask;
        }

        public async Task<Entities.Task> DeleteTaskAsync(int id)
        {
            var deletedTask = await _taskRepository.DeleteTaskAsync(id);
            return deletedTask;
        }
    }
}

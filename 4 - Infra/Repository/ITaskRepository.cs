namespace CurotecTaskBackApi.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Entities.Task>> GetAllTasksAsync();
        Task<Entities.Task> GetTaskByIdAsync(int id);
        Task<Entities.Task> AddTaskAsync(Entities.Task task);
        Task<Entities.Task> UpdateTaskAsync(Entities.Task task);
        Task<Entities.Task> DeleteTaskAsync(int id);
    }
}

namespace Domain.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<CurotecTaskBackApi.Entities.Task>> GetAllTasksAsync();
        Task<CurotecTaskBackApi.Entities.Task> GetTaskByIdAsync(int id);
        Task<CurotecTaskBackApi.Entities.Task> AddTaskAsync(CurotecTaskBackApi.Entities.Task task);
        Task<CurotecTaskBackApi.Entities.Task> UpdateTaskAsync(CurotecTaskBackApi.Entities.Task task);
        Task<CurotecTaskBackApi.Entities.Task> DeleteTaskAsync(int id);
    }
}

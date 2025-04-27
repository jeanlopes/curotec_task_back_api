using CurotecTaskBackApi.Repositories;

namespace CurotecTaskBackApi.Queries
{
    public class GetAllTasksQuery { }

    public class GetTaskByIdQuery
    {
        public int Id { get; set; }
    }

    public class TaskQueries
    {
        private readonly ITaskRepository _repository;

        public TaskQueries(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Entities.Task>> GetAllTasksAsync()
        {
            return await _repository.GetAllTasksAsync();
        }

        public async Task<Entities.Task> GetTaskByIdAsync(int id)
        {
            return await _repository.GetTaskByIdAsync(id);
        }
    }
}

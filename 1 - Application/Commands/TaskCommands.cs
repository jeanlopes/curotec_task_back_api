namespace CurotecTaskBackApi.Commands
{
    public class CreateTaskCommand
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
        public string Description { get; set; } = string.Empty;

        public Entities.TaskStatus Status { get; set; } = Entities.TaskStatus.Pending;
        public bool IsCompleted { get; set; } = false;
    }

    public class UpdateTaskCommand
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Entities.TaskStatus Status { get; set; } = Entities.TaskStatus.Pending;

        public bool IsCompleted { get; set; } = false;
    }

    public class DeleteTaskCommand
    {
        public int Id { get; set; }
    }
}

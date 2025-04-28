namespace CurotecTaskBackApi.Commands
{
    public class CreateTaskCommand
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Entities.TaskStatus Status { get; set; } = Entities.TaskStatus.Pending;
    }

    public class UpdateTaskCommand
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Entities.TaskStatus Status { get; set; } = Entities.TaskStatus.Pending;
    }

    public class DeleteTaskCommand
    {
        public int Id { get; set; }
    }
}

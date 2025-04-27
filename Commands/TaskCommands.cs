namespace CurotecTaskBackApi.Commands
{
    public class CreateTaskCommand
    {
        public string Title { get; set; } = string.Empty; // Default value provided
        public string Description { get; set; } = string.Empty; // Default value provided
        public string Status { get; set; } = "Pending"; // Default value provided
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Default value provided
    }

    public class UpdateTaskCommand
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Default value provided
        public string Description { get; set; } = string.Empty; // Default value provided
        public string Status { get; set; } = "Pending"; // Default value provided
    }

    public class DeleteTaskCommand
    {
        public int Id { get; set; }
    }
}

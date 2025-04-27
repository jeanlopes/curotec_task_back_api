namespace CurotecTaskBackApi.Commands
{
    public class CreateTaskCommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class UpdateTaskCommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class DeleteTaskCommand
    {
        public int Id { get; set; }
    }
}

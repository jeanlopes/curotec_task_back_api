namespace CurotecTaskBackApi.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string Name { get; set; } = string.Empty; // Added property
        public bool IsCompleted { get; set; } = false; // Added property

        // Parameterless constructor for initialization
        public Task() { }
    }
}

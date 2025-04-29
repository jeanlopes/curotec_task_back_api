using System.ComponentModel.DataAnnotations;

namespace CurotecTaskBackApi.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; } = (int)TaskStatus.Pending;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; } = false;

        public Task() { }
    }
}

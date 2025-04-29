using System.ComponentModel.DataAnnotations;

namespace CurotecTaskBackApi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, 2, ErrorMessage = "Status must be between 0 and 2.")]
        public int Status { get; set; } = (int)Entities.TaskStatus.Pending;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public bool IsCompleted { get; set; } = false;
    }
}

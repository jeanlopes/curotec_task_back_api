using System.Threading.Tasks;

namespace Api.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = TaskStatus.Pending.ToString();
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string Name { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
    }
}

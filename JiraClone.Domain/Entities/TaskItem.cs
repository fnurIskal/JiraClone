using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Domain.Entities
{
    public class TaskItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } =string.Empty;
        public string Description { get; set; } =string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public TaskStatus Status { get; set; } = TaskStatus.ToDo;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        public string ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public string AssignedUserId { get; set; }
        public User AssignedUser { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();


        public enum TaskStatus
        {
            ToDo = 1,
            InProgress = 2,
            Done = 3
        }

        public enum TaskPriority
        {
            Low = 1,
            Medium = 2,
            High = 3
        }

    }
}

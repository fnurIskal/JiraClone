using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Domain.Entities
{
    public class Project
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }  = DateTime.UtcNow;

        public string CreatedById { get; set; }

        public User CreatedBy { get; set; } = null!;

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
    }
}

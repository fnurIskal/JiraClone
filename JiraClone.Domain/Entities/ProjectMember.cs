using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Domain.Entities
{
    public class ProjectMember
    {
        public string ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public string UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
    }
}

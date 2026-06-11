using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Domain.Entities
{
    public class Comment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public string TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; } = null!;

        public string UserId { get; set; }

        public User User { get; set; } = null!;
    }
}

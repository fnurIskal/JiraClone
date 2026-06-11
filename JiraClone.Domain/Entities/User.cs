using System;
using System.Collections.Generic;

namespace JiraClone.Domain.Entities
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role {  get; set; }

        public ICollection<Project> OwnedProjects { get; set; } = new List<Project>();

        public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
        public ICollection<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();

        public enum UserRole
        {
            Admin =0,
            Employee = 1,
        }
    }
}

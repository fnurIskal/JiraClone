using JiraClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClone.Infrastructure.Persistance.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Description)
                .HasMaxLength(1000);

            builder.Property(t => t.Status)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(t => t.Priority)
              .HasConversion<string>()
              .HasMaxLength(20);

            builder.HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.AssignedUser)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

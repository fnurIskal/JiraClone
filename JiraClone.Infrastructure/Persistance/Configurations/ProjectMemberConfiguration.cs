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
    public class ProjectMemberConfiguration : IEntityTypeConfiguration<ProjectMember>
    {
        public void Configure(EntityTypeBuilder<ProjectMember> builder)
        {
            builder.HasKey(pm => new { pm.ProjectId, pm.UserId });

            builder.HasOne(pm => pm.Project)
                .WithMany(p => p.ProjectMembers)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pm => pm.User)
                .WithMany(u => u.ProjectMembers)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}


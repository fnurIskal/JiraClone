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
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>

    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.HasOne(p => p.CreatedBy)
                .WithMany(u => u.OwnedProjects)
                .HasForeignKey(p => p.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}

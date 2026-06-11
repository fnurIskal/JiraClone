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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.Property(u => u.Role)
                .HasConversion<string>()
                .HasMaxLength(20);

            // 1 admin -> many projects
            builder.HasMany(u => u.OwnedProjects)
                .WithOne(p => p.CreatedBy)
                .HasForeignKey(p => p.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
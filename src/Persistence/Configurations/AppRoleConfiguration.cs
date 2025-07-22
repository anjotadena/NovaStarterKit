using System.Diagnostics.Metrics;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(r => r.Description)
            .HasMaxLength(255);

        builder.Property(r => r.IsActive)
            .HasDefaultValue(true);

        builder.Property(r => r.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(r => r.UpdatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        // Index for unique role name
        builder.HasIndex(r => r.Name)
            .IsUnique();

        // Seed Data for default roles
        builder.HasData(
        new
        {
                Id = Guid.Parse($"7A2B59D7-B603-406D-99A6-0955792DFC90"), // Static GUID pattern
                Name = "Admin",
                Description = "System Administrator with full access",
                IsActive = true,
                CreatedAt = DateTime.Parse("2025-01-01"),
                UpdatedAt = DateTime.Parse("2025-01-01"),
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new
            {
                Id = Guid.Parse($"7A2B59D7-B603-406D-99A6-0955792DFC91"), // Static GUID pattern
                Name = "User",
                Description = "Standard user with limited access",
                IsActive = true,
                CreatedAt = DateTime.Parse("2025-01-01"),
                UpdatedAt = DateTime.Parse("2025-01-01"),
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new
            {
                Id = Guid.Parse($"7A2B59D7-B603-406D-99A6-0955792DFC92"), // Static GUID pattern
                Name = "Moderator",
                Description = "Moderator with content management permissions",
                IsActive = true,
                CreatedAt = DateTime.Parse("2025-01-01"),
                UpdatedAt = DateTime.Parse("2025-01-01"),
                CreatedBy = "System",
                UpdatedBy = "System"
            });
    }
}

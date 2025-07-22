using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Resource)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Action)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(255);

        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(p => p.UpdatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        // Composite unique index for Resource + Action  
        builder.HasIndex(p => new { p.Resource, p.Action })
            .IsUnique();

        // Seed default permissions  
        var permissions = GetDefaultPermissions();
        builder.HasData(permissions);
    }

    private static Permission[] GetDefaultPermissions()
    {
        var permissions = new List<Permission>();
        var counter = 1;

        var resources = new[] { "Users", "Roles", "Permissions", "Content", "Reports", "Settings" };
        var actions = new[] { "Create", "Read", "Update", "Delete", "Manage" };

        foreach (var resource in resources)
        {
            foreach (var action in actions)
            {
                permissions.Add(new Permission
                {
                    Id = Guid.Parse($"550e8400-e29b-41d4-a716-44665544{counter:D4}"), // Fixed: Added Id with unique GUID
                    Name = $"{resource}.{action}",
                    Resource = resource,
                    Action = action,
                    Description = $"Permission to {action.ToLower()} {resource.ToLower()}",
                    CreatedBy = "System",
                    UpdatedBy = "System"
                });
                counter++;
            }
        }

        return permissions.ToArray();
    }
}



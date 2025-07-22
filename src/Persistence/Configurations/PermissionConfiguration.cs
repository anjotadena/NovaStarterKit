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
        var staticDateTime = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        return new[]
        {
            // Users permissions (1-5)
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440001"),
                Name = "Users.Create",
                Resource = "Users",
                Action = "Create",
                Description = "Permission to create users",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440002"),
                Name = "Users.Read",
                Resource = "Users",
                Action = "Read",
                Description = "Permission to read users",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440003"),
                Name = "Users.Update",
                Resource = "Users",
                Action = "Update",
                Description = "Permission to update users",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440004"),
                Name = "Users.Delete",
                Resource = "Users",
                Action = "Delete",
                Description = "Permission to delete users",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440005"),
                Name = "Users.Manage",
                Resource = "Users",
                Action = "Manage",
                Description = "Permission to manage users",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },

            // Roles permissions (6-10)
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440006"),
                Name = "Roles.Create",
                Resource = "Roles",
                Action = "Create",
                Description = "Permission to create roles",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440007"),
                Name = "Roles.Read",
                Resource = "Roles",
                Action = "Read",
                Description = "Permission to read roles",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440008"),
                Name = "Roles.Update",
                Resource = "Roles",
                Action = "Update",
                Description = "Permission to update roles",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440009"),
                Name = "Roles.Delete",
                Resource = "Roles",
                Action = "Delete",
                Description = "Permission to delete roles",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440010"),
                Name = "Roles.Manage",
                Resource = "Roles",
                Action = "Manage",
                Description = "Permission to manage roles",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },

            // Permissions permissions (11-15)
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440011"),
                Name = "Permissions.Create",
                Resource = "Permissions",
                Action = "Create",
                Description = "Permission to create permissions",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440012"),
                Name = "Permissions.Read",
                Resource = "Permissions",
                Action = "Read",
                Description = "Permission to read permissions",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440013"),
                Name = "Permissions.Update",
                Resource = "Permissions",
                Action = "Update",
                Description = "Permission to update permissions",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440014"),
                Name = "Permissions.Delete",
                Resource = "Permissions",
                Action = "Delete",
                Description = "Permission to delete permissions",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440015"),
                Name = "Permissions.Manage",
                Resource = "Permissions",
                Action = "Manage",
                Description = "Permission to manage permissions",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },

            // Content permissions (16-20)
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440016"),
                Name = "Content.Create",
                Resource = "Content",
                Action = "Create",
                Description = "Permission to create content",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440017"),
                Name = "Content.Read",
                Resource = "Content",
                Action = "Read",
                Description = "Permission to read content",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440018"),
                Name = "Content.Update",
                Resource = "Content",
                Action = "Update",
                Description = "Permission to update content",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440019"),
                Name = "Content.Delete",
                Resource = "Content",
                Action = "Delete",
                Description = "Permission to delete content",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440020"),
                Name = "Content.Manage",
                Resource = "Content",
                Action = "Manage",
                Description = "Permission to manage content",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },

            // Reports permissions (21-25)
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440021"),
                Name = "Reports.Create",
                Resource = "Reports",
                Action = "Create",
                Description = "Permission to create reports",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440022"),
                Name = "Reports.Read",
                Resource = "Reports",
                Action = "Read",
                Description = "Permission to read reports",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440023"),
                Name = "Reports.Update",
                Resource = "Reports",
                Action = "Update",
                Description = "Permission to update reports",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440024"),
                Name = "Reports.Delete",
                Resource = "Reports",
                Action = "Delete",
                Description = "Permission to delete reports",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440025"),
                Name = "Reports.Manage",
                Resource = "Reports",
                Action = "Manage",
                Description = "Permission to manage reports",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },

            // Settings permissions (26-30)
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440026"),
                Name = "Settings.Create",
                Resource = "Settings",
                Action = "Create",
                Description = "Permission to create settings",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440027"),
                Name = "Settings.Read",
                Resource = "Settings",
                Action = "Read",
                Description = "Permission to read settings",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440028"),
                Name = "Settings.Update",
                Resource = "Settings",
                Action = "Update",
                Description = "Permission to update settings",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440029"),
                Name = "Settings.Delete",
                Resource = "Settings",
                Action = "Delete",
                Description = "Permission to delete settings",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Permission
            {
                Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440030"),
                Name = "Settings.Manage",
                Resource = "Settings",
                Action = "Manage",
                Description = "Permission to manage settings",
                CreatedAt = staticDateTime,
                UpdatedAt = staticDateTime,
                CreatedBy = "System",
                UpdatedBy = "System"
            }
        };
    }
}



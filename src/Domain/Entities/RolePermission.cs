namespace Domain.Entities;

public class RolePermission
{
    public Guid RoleId { get; set; }

    public virtual AppRole Role { get; set; } = null!;

    public Guid PermissionId { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
}

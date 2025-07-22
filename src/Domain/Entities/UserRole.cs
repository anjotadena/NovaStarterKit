namespace Domain.Entities;

public class UserRole
{
    public Guid UserId { get; set; }

    public virtual AppUser User { get; set; } = null!;

    public Guid RoleId { get; set; }

    public virtual AppRole Role { get; set; } = null!;

    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

    public string AssignedBy { get; set; } = string.Empty;
}

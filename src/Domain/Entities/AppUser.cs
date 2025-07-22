using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class AppUser : BaseEntity<Guid>
{
    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public Email Email { get; private set; } = default!;

    public string HashedPassword { get; private set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsEmailConfirmed { get; set; } = false;

    public DateTime? LastLoginDate { get; set; }

    public string SecurityStamp { get; set; } = string.Empty;

    public string ConcurrencyStamp { get; set; } = string.Empty;

    public int FailedLoginAttempts { get; set; } = 0;

    public DateTime? LockoutEnd { get; set; }

    // Navigation properties
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    // Computed properties
    public string FullName => $"{FirstName} {LastName}".Trim();

    public bool IsLockedOut => LockoutEnd.HasValue && LockoutEnd > DateTime.UtcNow;
}

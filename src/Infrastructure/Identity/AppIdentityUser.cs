using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class AppIdentityUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime? LastLoginDate { get; set; }

    public int FailedLoginAttempts { get; set; } = 0;

    // Map to/from Domain entity
    public static AppIdentityUser FromDomain(AppUser user)
    {
        return new AppIdentityUser
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email.Value,
            PhoneNumber = user.PhoneNumber,
            IsActive = user.IsActive,
            EmailConfirmed = user.IsEmailConfirmed,
            LastLoginDate = user.LastLoginDate,
            LockoutEnd = user.LockoutEnd,
        };
    }

    public AppUser ToDomain()
    {
        throw new NotImplementedException("Implement domain entity creation.");
    }
}

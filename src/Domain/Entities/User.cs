using System.Net.Sockets;
using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class User : BaseEntity<Guid>
{
    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public Email Email { get; private set; } = default!;

    public string HashedPassword { get; private set; } = string.Empty;

    public Role Role { get; private set; } = default!;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private User() { }

    public User(string firstName, string lastName, Email email, string password, Role role)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        Role = role;
    }

    public void ChangePassword(string value)
    {
        HashedPassword = value;
    }

    public void ChangeEmail(Email value)
    {
        Email = value;
    }

    public bool VerifyPassword(string password) => BCrypt.Net.BCrypt.Verify(password, HashedPassword);
}

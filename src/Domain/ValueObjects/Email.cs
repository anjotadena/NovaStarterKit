using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public sealed record Email
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value.ToLowerInvariant(); // Normalize
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("Email is required");
        }

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new ArgumentException("Invalid email format");
        }

        return new Email(email);
    }

    public override string ToString() => Value;
}

﻿using Domain.Common;

namespace Domain.Entities;

public class RefreshToken : BaseEntity<Guid>
{
    public string Token { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }

    public bool IsRevoked { get; set; } = false;

    public DateTime? RevokedAt { get; set; }

    public string? RevokedBy { get; set; }

    public string? ReplacedByToken { get; set; }

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

    public bool IsActive => !IsRevoked && !IsExpired;
}

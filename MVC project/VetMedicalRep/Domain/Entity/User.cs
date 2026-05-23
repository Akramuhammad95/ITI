using System;

namespace Domain.Entities;

/// <summary>
/// Represents a system user — primarily a Medical Representative.
/// 
/// Business Rules:
/// - Email must be valid and non-empty
/// - Full name cannot be empty
/// - A rep can be assigned to at most one Area at a time
/// - An inactive user cannot conduct visits
/// - Password is stored as hash (never plain text)
/// </summary>
public class User 
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    //public UserRole Role { get; private set; }
    public bool IsActive { get; private set; }

    private User() { }

    public User(string fullName, string email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Full name cannot be empty.", nameof(fullName));
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@')) throw new ArgumentException("A valid email address is required.", nameof(email));
        if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));

        Id = Guid.NewGuid();
        FullName = fullName.Trim();
        Email = email.Trim().ToLowerInvariant();
        PasswordHash = passwordHash;
        IsActive = true;
    }
}

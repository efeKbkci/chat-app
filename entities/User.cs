using System;

namespace chat_app.entities;

public enum UserRole
{
    Regular,
    Admin
}

public class User
{
    public Guid ID { get; private set; } = Guid.NewGuid();
    public string Username { get; private set; }
    public UserRole Role { get; private set; }

    public User(string username, UserRole role)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username cannot be null or empty.", nameof(username));
        }

        Username = username;
        Role = role;
    }
}


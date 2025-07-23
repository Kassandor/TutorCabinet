using TutorCabinet.Core.Interfaces;
using TutorCabinet.Core.ValueObjects;

namespace TutorCabinet.Core.Entities;

/// <summary>
/// Доменная сущность Пользователь
/// </summary>
public class User
{
    public Guid Id { get; set; }
    public Email Email { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string PasswordHash { get; set; }

    protected User()
    {
    }

    public User(Guid id, Email email, string name)
    {
        Id = id;
        Email = email;
        Name = name;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Установка пароля
    /// </summary>
    /// <param name="passwordHash">Хеш пароля</param>
    public void SetPassword(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentNullException(nameof(passwordHash), "Хеш пароля не может быть пустым");
        PasswordHash = passwordHash;
    }

    /// <summary>
    /// Верификация пароля
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <param name="hasher">Хешер паролей</param>
    /// <returns></returns>
    public bool VerifyPassword(string password, IPasswordHasher hasher) => hasher.Verify(password, PasswordHash);
}
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Core.ValueObjects;

namespace TutorCabinet.Core.Entities;

/// <summary>
/// Доменная сущность Пользователь
/// </summary>
public class User
{
    public Guid Id { get; }
    public Email Email { get; }
    public string Name { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    public string PasswordHash { get; }

    private User(
        Guid id,
        Email email,
        string name,
        string passwordHash,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        Id = id;
        Email = email;
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        PasswordHash = passwordHash;
    }

    /// <summary>
    /// Фабричный метод создания нового пользователя
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="email">Email</param>
    /// <param name="name">Name</param>
    /// <param name="passwordHash">Хеш пароля</param>
    /// <returns></returns>
    public static User Create(Guid id, Email email, string name, string passwordHash)
    {
        var now = DateTime.UtcNow;
        return new User(id, email, name, passwordHash, now, now);
    }

    /// <summary>
    /// Фабричный метод, возвращающий пользователя
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="email">Email</param>
    /// <param name="name">Name</param>
    /// <param name="passwordHash">Хеш пароля</param>
    /// <param name="createdAt">Дата создания</param>
    /// <param name="updatedAt">Дата обновления</param>
    /// <returns></returns>
    public static User Get(
        Guid id,
        Email email,
        string name,
        string passwordHash,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        return new User(id, email, name, passwordHash, createdAt, updatedAt);
    }

    /// <summary>
    /// Верификация пароля
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <param name="hasher">Хешер паролей</param>
    /// <returns></returns>
    public bool VerifyPassword(string password, IPasswordHasher hasher) =>
        hasher.Verify(password, PasswordHash);
}

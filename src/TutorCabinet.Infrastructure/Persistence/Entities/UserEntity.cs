using TutorCabinet.Core.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Entities;

/// <summary>
/// Представление <see cref="User"/> в базе данных
/// </summary>
public class UserEntity
{
    public Guid Id { get; init; }

    public string Email { get; init; } = null!;

    public string Name { get; init; } = null!;

    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }

    public string PasswordHash { get; init; } = null!;
}

using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces.Persistence;

namespace TutorCabinet.Infrastructure.Persistence.Entities;

/// <summary>
/// Представление <see cref="User"/> в базе данных
/// </summary>
public class UserEntity : IEntity
{
    public Guid Id { get; init; }
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}

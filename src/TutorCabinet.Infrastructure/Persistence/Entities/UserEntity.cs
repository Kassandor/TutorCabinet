using System.ComponentModel.DataAnnotations;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Entities;

/// <summary>
/// Представление <see cref="User"/> в базе данных
/// </summary>
public class UserEntity
{
    public Guid Id { get; init; }

    [MaxLength(320)]
    public string Email { get; set; } = null!;

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }

    public string PasswordHash { get; set; } = null!;
}

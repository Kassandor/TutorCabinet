using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces.Persistence;

namespace TutorCabinet.Infrastructure.Persistence.Entities;

/// <summary>
/// Представление <see cref="DirectionStudy"/> в базе данных
/// </summary>
public class DirectionStudyEntity : IEntity
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public ICollection<StudentEntity>? Students { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}

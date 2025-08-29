using TutorCabinet.Core.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Entities;

/// <summary>
/// Представление <see cref="DirectionStudy"/> в базе данных
/// </summary>
public class DirectionStudyEntity
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public ICollection<StudentEntity>? Students { get; init; }
}

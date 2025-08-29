using TutorCabinet.Core.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Entities;

/// <summary>
/// Представление <see cref="Student"/>
/// </summary>
public class StudentEntity
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public int ClassNumber { get; init; }
    public Guid DirectionStudyId { get; init; }
    public DirectionStudyEntity? DirectionStudy { get; init; }
}

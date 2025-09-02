using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces.Persistence;

namespace TutorCabinet.Infrastructure.Persistence.Entities;

/// <summary>
/// Представление <see cref="Student"/>
/// </summary>
public class StudentEntity : IEntity
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public int ClassNumber { get; init; }
    public Guid DirectionStudyId { get; init; }
    public DirectionStudyEntity? DirectionStudy { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}

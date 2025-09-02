using TutorCabinet.Core.Interfaces.Entities;

namespace TutorCabinet.Core.Entities;

/// <summary>
/// Доменная сущность Студент
/// </summary>
public class Student : IDomain
{
    public Guid Id { get; }
    public string Name { get; }
    public int ClassNumber { get; }
    public Guid DirectionStudyId { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private Student(
        Guid id,
        string name,
        int classNumber,
        DateTime createdAt,
        DateTime updatedAt,
        Guid directionStudyId
    )
    {
        Id = id;
        Name = name;
        DirectionStudyId = directionStudyId;
        ClassNumber = classNumber;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Student Create(
        Guid id,
        string name,
        int classNumber,
        Guid directionStudyId
    )
    {
        var now = DateTime.UtcNow;
        return new Student(id, name, classNumber, now, now, directionStudyId);
    }

    public static Student Get(
        Guid id,
        string name,
        int classNumber,
        DateTime createdAt,
        DateTime updatedAt,
        Guid directionStudyId
    )
    {
        return new Student(id, name, classNumber, createdAt, updatedAt, directionStudyId);
    }
}

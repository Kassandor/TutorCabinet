namespace TutorCabinet.Core.Entities;

/// <summary>
/// Доменная сущность Студент
/// </summary>
public class Student
{
    public Guid Id { get; }
    public string Name { get; }
    public int ClassNumber { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    public DirectionStudy? DirectionStudy { get; }

    private Student(
        Guid id,
        string name,
        int classNumber,
        DateTime createdAt,
        DateTime updatedAt,
        DirectionStudy? directionStudy
    )
    {
        Id = id;
        Name = name;
        DirectionStudy = directionStudy;
        ClassNumber = classNumber;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Student Create(
        Guid id,
        string name,
        int classNumber,
        DirectionStudy directionStudy
    )
    {
        var now = DateTime.UtcNow;
        return new Student(id, name, classNumber, now, now, directionStudy);
    }

    public static Student Get(
        Guid id,
        string name,
        int classNumber,
        DateTime createdAt,
        DateTime updatedAt,
        DirectionStudy? directionStudy = null
    )
    {
        return new Student(id, name, classNumber, createdAt, updatedAt, directionStudy);
    }
}

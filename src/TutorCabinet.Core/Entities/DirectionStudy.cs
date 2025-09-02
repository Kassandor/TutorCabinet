using TutorCabinet.Core.Interfaces.Entities;

namespace TutorCabinet.Core.Entities;

/// <summary>
/// Доменная сущность Направление подготовки
/// </summary>
public class DirectionStudy : IDomain
{
    public Guid Id { get; }
    public string Name { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private DirectionStudy(Guid id, string name, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static DirectionStudy Create(Guid id, string name, ICollection<Student>? students = null)
    {
        var now = DateTime.UtcNow;
        return new DirectionStudy(id, name, now, now);
    }

    public static DirectionStudy Get(Guid id, string name, DateTime createdAt, DateTime updatedAt)
    {
        return new DirectionStudy(id, name, createdAt, updatedAt);
    }
}

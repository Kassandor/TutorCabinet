namespace TutorCabinet.Core.Entities;

/// <summary>
/// Доменная сущность Направление подготовки
/// </summary>
public class DirectionStudy
{
    public Guid Id { get; }
    public string Name { get; }
    public ICollection<Student>? Students { get; }

    private DirectionStudy(Guid id, string name, ICollection<Student>? students)
    {
        Id = id;
        Name = name;
        Students = students;
    }

    public static DirectionStudy Create(Guid id, string name, ICollection<Student>? students = null)
    {
        return new DirectionStudy(id, name, students);
    }

    public static DirectionStudy Get(Guid id, string name, ICollection<Student>? students = null)
    {
        return new DirectionStudy(id, name, students);
    }
}

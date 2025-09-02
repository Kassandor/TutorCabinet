using TutorCabinet.Core.Entities;
using TutorCabinet.Infrastructure.Persistence.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Mappers;

public static class StudentMapper
{
    public static Student ToDomain(this StudentEntity entity)
    {
        return Student.Get(
            entity.Id,
            entity.Name,
            entity.ClassNumber,
            entity.CreatedAt,
            entity.UpdatedAt,
            entity.DirectionStudyId
        );
    }

    public static StudentEntity ToEntity(this Student domain)
    {
        return new StudentEntity
        {
            Id = domain.Id,
            Name = domain.Name,
            ClassNumber = domain.ClassNumber,
            CreatedAt = domain.CreatedAt,
            UpdatedAt = domain.UpdatedAt,
            DirectionStudyId = domain.DirectionStudyId,
        };
    }
}

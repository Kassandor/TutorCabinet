using TutorCabinet.Core.Entities;
using TutorCabinet.Infrastructure.Persistence.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Mappers;

public static class DirectionStudyMapper
{
    public static DirectionStudy ToDomain(this DirectionStudyEntity entity)
    {
        return DirectionStudy.Get(
            entity.Id,
            entity.Name,
            entity.CreatedAt,
            entity.UpdatedAt
        );
    }

    public static DirectionStudyEntity ToEntity(this DirectionStudy domain)
    {
        return new DirectionStudyEntity
        {
            Id = domain.Id,
            Name = domain.Name,
            CreatedAt = domain.CreatedAt,
            UpdatedAt = domain.UpdatedAt,
        };
    }
}

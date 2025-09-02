using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces.Persistence.Repositories;
using TutorCabinet.Infrastructure.Persistence.Contexts;
using TutorCabinet.Infrastructure.Persistence.Entities;
using TutorCabinet.Infrastructure.Persistence.Mappers;

namespace TutorCabinet.Infrastructure.Persistence.Repositories;

public class DirectionStudyRepository(AppDbContext ctx)
    : BaseRepository<DirectionStudyEntity, DirectionStudy>(ctx),
        IDirectionStudyRepository
{
    protected override DirectionStudy ToDomain(DirectionStudyEntity entity)
    {
        return entity.ToDomain();
    }

    protected override DirectionStudyEntity ToEntity(DirectionStudy domain)
    {
        return domain.ToEntity();
    }
}

using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces.Persistence.Repositories;
using TutorCabinet.Infrastructure.Persistence.Contexts;
using TutorCabinet.Infrastructure.Persistence.Entities;

namespace TutorCabinet.Infrastructure.Persistence.Repositories;

public class DirectionStudyRepository(AppDbContext ctx)
    : BaseRepository<DirectionStudyEntity, DirectionStudy>(ctx),
        IDirectionStudyRepository
{
    protected override DirectionStudy ToDomain(DirectionStudyEntity entity)
    {
        return DirectionStudy.Get(entity.Id, entity.Name, entity.CreatedAt, entity.UpdatedAt);
    }

    protected override DirectionStudyEntity ToEntity(DirectionStudy domain)
    {
        throw new NotImplementedException();
    }
}

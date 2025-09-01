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
        throw new NotImplementedException();
    }

    protected override DirectionStudyEntity ToEntity(DirectionStudy domain)
    {
        throw new NotImplementedException();
    }
}

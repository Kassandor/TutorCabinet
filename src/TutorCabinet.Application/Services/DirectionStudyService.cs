using System.Data.Common;
using TutorCabinet.Application.DTOs.DirectionStudies;
using TutorCabinet.Application.Interfaces.Services;
using TutorCabinet.Core.Entities;
using TutorCabinet.Core.Interfaces;
using TutorCabinet.Core.Interfaces.Persistence.Repositories;

namespace TutorCabinet.Application.Services;

public class DirectionStudyService(IDirectionStudyRepository repo, IUnitOfWork uow)
    : IDirectionStudyService
{
    public async Task<Guid> CreateAsync(
        CreateDirectionStudyDto dto,
        CancellationToken cancellationToken
    )
    {
        var study = DirectionStudy.Create(Guid.NewGuid(), dto.Name);
        try
        {
            await repo.AddAsync(study, cancellationToken);
            await uow.SaveChangesAsync(cancellationToken);
            return study.Id;
        }
        catch (DbException ex)
        {
            throw new InvalidOperationException("Unable to create direction study", ex);
        }
    }

    public async Task<DirectionStudiesListDto?> GetAllAsync(CancellationToken cancellationToken)
    {
        var studies = await repo.GetAllAsync(cancellationToken);
        if (studies is null)
            return null;
        var studiesDto = studies.Select(s => new DirectionStudyDto(s.Id, s.Name)).ToList();
        return new DirectionStudiesListDto(studiesDto, studiesDto.Count);
    }

    public async Task<DirectionStudyDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var study = await repo.GetByIdAsync(id, cancellationToken);
        return study is null ? null : new DirectionStudyDto(study.Id, study.Name);
    }
}

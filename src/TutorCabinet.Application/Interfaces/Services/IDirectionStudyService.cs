using TutorCabinet.Application.DTOs.DirectionStudies;
using TutorCabinet.Application.DTOs.Students;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.Interfaces.Services;

public interface IDirectionStudyService
{
    /// <summary>
    /// Создание <see cref="DirectionStudy"/>
    /// </summary>
    /// <param name="dto"><see cref="CreateDirectionStudyDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Guid"/></returns>
    Task<Guid> CreateAsync(CreateDirectionStudyDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех <see cref="DirectionStudy"/>
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="DirectionStudiesListDto"/>?</returns>
    Task<DirectionStudiesListDto?> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получение <see cref="DirectionStudy"/> по id
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="StudentDto"/>?</returns>
    Task<DirectionStudyDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}

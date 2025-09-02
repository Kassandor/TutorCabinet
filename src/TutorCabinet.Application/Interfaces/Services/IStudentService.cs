using TutorCabinet.Application.DTOs.Students;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.Interfaces.Services;

public interface IStudentService
{
    /// <summary>
    /// Создание <see cref="Student"/>
    /// </summary>
    /// <param name="dto"><see cref="CreateStudentDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Guid"/></returns>
    Task<Guid> CreateAsync(CreateStudentDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех <see cref="Student"/>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="StudentsListDto"/>?</returns>
    Task<StudentsListDto?> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получение <see cref="Student"/> по id
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="StudentDto"/>?</returns>
    Task<StudentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}

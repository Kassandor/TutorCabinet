using TutorCabinet.Core.Interfaces.Entities;

namespace TutorCabinet.Core.Interfaces.Persistence.Repositories;

/// <summary>
/// Базовый CRUD репозиторий
/// </summary>
/// <typeparam name="TDomain">Тип доменной модели</typeparam>
public interface IBaseRepository<TDomain>
    where TDomain : class, IDomain
{
    /// <summary>
    /// Получение списка записей <typeparamref name="TDomain"/> из базы данных
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<List<TDomain>?> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получение записи <typeparamref name="TDomain"/> по переданному <see cref="Guid"/> из базы данных
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<TDomain?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Проверка, существует ли представление <typeparamref name="TDomain"/> в базе данных
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Добавление записи <typeparamref name="TDomain"/> в базу данных
    /// </summary>
    /// <param name="domainModel">Инстанс <typeparamref name="TDomain"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task AddAsync(TDomain domainModel, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление записи <typeparamref name="TDomain"/> из базы данных
    /// </summary>
    /// <param name="domainModel"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(TDomain domainModel, CancellationToken cancellationToken);
}

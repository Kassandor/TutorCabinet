using TutorCabinet.Core.Entities;

namespace TutorCabinet.Core.Interfaces;

/// <summary>
/// Репозиторий <see cref="User"/>
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Получение списка <see cref="User"/>
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<List<User>?> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получение <see cref="User"/> по id
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получение <see cref="User"/> по email из базы данных
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Добавление <see cref="User"/> в базу данных
    /// </summary>
    /// <param name="user"><see cref="User"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task AddAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновление данных <see cref="User"/> в базе данных
    /// </summary>
    /// <param name="user"><see cref="User"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаление <see cref="User"/> из базы данных
    /// </summary>
    /// <param name="user"><see cref="User"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task DeleteAsync(User user, CancellationToken cancellationToken = default);
}
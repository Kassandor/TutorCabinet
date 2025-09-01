using TutorCabinet.Core.Entities;

namespace TutorCabinet.Core.Interfaces.Persistence.Repositories;

/// <summary>
/// Репозиторий <see cref="User"/>
/// </summary>
public interface IUserRepository : IBaseRepository<User>
{
    /// <summary>
    /// Получение <see cref="User"/> по email из базы данных
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    /// <summary>
    /// Обновление данных <see cref="User"/> в базе данных
    /// </summary>
    /// <param name="user"><see cref="User"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task UpdateAsync(User user, CancellationToken cancellationToken);
}

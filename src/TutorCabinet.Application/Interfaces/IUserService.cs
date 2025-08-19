using System.Security.Claims;
using TutorCabinet.Application.DTOs;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.Interfaces;

/// <summary>
/// Сервис доменной сущности <see cref="User"/>
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Создание <see cref="User"/>
    /// </summary>
    /// <param name="dto"><see cref="CreateUserDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Guid"/></returns>
    Task<Guid> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех <see cref="User"/>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="UsersListDto"/>?</returns>
    Task<UsersListDto?> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получение <see cref="User"/> по id
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="UserDto"/>?</returns>
    Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение <see cref="User"/> по <see cref="ClaimsPrincipal"/>
    /// </summary>
    /// <param name="user"><see cref="ClaimsPrincipal"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="UserDto"/>?</returns>
    Task<UserDto?> GetByCurrentUserAsync(ClaimsPrincipal user, CancellationToken cancellationToken);

    /// <summary>
    /// Проверка данных <see cref="User"/> для авторизации
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="password">Пароль</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="bool"/></returns>
    Task<bool> CheckCredentialsAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Обновление данных <see cref="User"/>
    /// </summary>
    /// <param name="dto"><see cref="UpdateUserDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task UpdateAsync(UpdateUserDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление <see cref="User"/>
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}

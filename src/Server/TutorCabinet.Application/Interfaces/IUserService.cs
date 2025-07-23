using TutorCabinet.Application.DTOs;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.Interfaces;

/// <summary>
/// Сервис доменной сущности <see cref="User"/>
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Создание пользователя
    /// </summary>
    /// <param name="dto"><see cref="CreateUserDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<Guid> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получение пользователя по id
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка данных для авторизации
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="password">Пароль</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<bool> CheckCredentialsAsync(string email, string password, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновление данных пользователя
    /// </summary>
    /// <param name="dto"><see cref="UpdateUserDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task UpdateAsync(UpdateUserDto dto, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
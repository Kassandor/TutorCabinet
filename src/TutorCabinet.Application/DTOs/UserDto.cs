namespace TutorCabinet.Application.DTOs;

/// <summary>
/// DTO списка пользователей
/// </summary>
/// <param name="Users">Коллекция <see cref="UserDto"/></param>
/// <param name="TotalCount">Количество пользователей</param>
public sealed record UsersListDto(List<UserDto> Users, int TotalCount);

/// <summary>
/// DTO пользователя
/// </summary>
public sealed record UserDto(Guid Id, string Email, string Name);

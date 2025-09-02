namespace TutorCabinet.Application.DTOs.Users;

/// <summary>
/// DTO списка пользователей
/// </summary>
/// <param name="Users">Коллекция <see cref="UserDto"/></param>
/// <param name="TotalCount">Количество пользователей</param>
public sealed record UsersListDto(List<UserDto> Users, int TotalCount);

namespace TutorCabinet.Application.DTOs.Users;

/// <summary>
/// DTO пользователя
/// </summary>
public sealed record UserDto(Guid Id, string Email, string Name);

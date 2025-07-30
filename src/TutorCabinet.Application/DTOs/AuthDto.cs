namespace TutorCabinet.Application.DTOs;

/// <summary>
/// DTO аутентификации пользователя
/// </summary>
/// <param name="Email">Email</param>
/// <param name="Password"></param>
public sealed record AuthUserDto(string Email, string Password);
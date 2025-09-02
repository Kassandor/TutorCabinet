namespace TutorCabinet.Application.DTOs;

/// <summary>
/// DTO аутентификации пользователя
/// </summary>
/// <param name="Email">Email</param>
/// <param name="Password">Пароль</param>
public sealed record AuthUserDto(string Email, string Password);

/// <summary>
/// DTO для обновления пары JWT токенов
/// </summary>
/// <param name="RefreshToken">Refresh Token</param>
public sealed record RefreshTokenDto(string RefreshToken);

/// <summary>
/// DTO содержащий пару Access + Resfresh токенов
/// </summary>
/// <param name="AccessToken">AccessToken</param>
/// <param name="RefreshToken">RefreshToken</param>
public sealed record TokenPair(string AccessToken, string RefreshToken);

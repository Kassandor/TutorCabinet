using TutorCabinet.Application.DTOs;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.Interfaces;

/// <summary>
/// Функционал для генерации JWT токенов
/// </summary>
public interface IJwtProvider
{
    /// <summary>
    /// Генерирует пару <see cref="TokenPair"/>
    /// </summary>
    /// <param name="user"><see cref="User"/></param>
    /// <returns></returns>
    TokenPair GenerateTokens(User user);

    string? GetEmailFromToken(string token);
}
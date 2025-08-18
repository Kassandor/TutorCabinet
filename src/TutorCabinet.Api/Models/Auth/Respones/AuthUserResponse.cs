using TutorCabinet.Application.DTOs;

namespace TutorCabinet.Api.Models.Auth.Respones;

/// <summary>
/// API ответ, содержащий пару сгенерированных JWT токенов
/// </summary>
/// <param name="Tokens"><see cref="TokenPair"/></param>
public sealed record AuthUserResponse(TokenPair Tokens);

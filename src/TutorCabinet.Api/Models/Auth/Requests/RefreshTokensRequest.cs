using System.ComponentModel.DataAnnotations;

namespace TutorCabinet.Api.Models.Auth.Requests;

/// <summary>
/// Запрос на обновление JWT токенов
/// </summary>
public class RefreshTokensRequest
{
    public required string RefreshToken { get; init; }
}
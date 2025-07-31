using System.ComponentModel.DataAnnotations;

namespace TutorCabinet.Api.Models.Auth.Requests;

/// <summary>
/// Запрос на обновление JWT токенов
/// </summary>
public class RefreshTokensRequest
{
    [EmailAddress] public required string Email { get; init; }
    public required string RefreshToken { get; init; }
}
using System.ComponentModel.DataAnnotations;

namespace TutorCabinet.Api.Models.Auth.Requests;

/// <summary>
/// Запрос на аутентификацию пользователя
/// </summary>
public class AuthUserRequest
{
    [Required, EmailAddress] public required string Email { get; init; }

    [Required, StringLength(100, MinimumLength = 6), DataType(DataType.Password)]
    public required string Password { get; init; }
}
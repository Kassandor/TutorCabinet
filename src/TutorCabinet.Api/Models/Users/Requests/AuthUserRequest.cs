using System.ComponentModel.DataAnnotations;

namespace TutorCabinet.Api.Models.Users.Requests;

public class AuthUserRequest
{
    [Required, EmailAddress] public required string Email { get; init; }

    [Required, StringLength(100, MinimumLength = 6), DataType(DataType.Password)]
    public required string Password { get; init; }
}
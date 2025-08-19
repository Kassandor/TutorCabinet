using System.ComponentModel.DataAnnotations;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models.Users.Requests;

/// <summary>
/// API-запрос создания <see cref="User"/>
/// </summary>
public class CreateUserRequest
{
    [Required, EmailAddress, StringLength(320, MinimumLength = 8)]
    public required string Email { get; init; }

    [Required, StringLength(100, MinimumLength = 2)]
    public required string Name { get; init; }

    [Required, StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Password)]
    public required string Password { get; init; }
}

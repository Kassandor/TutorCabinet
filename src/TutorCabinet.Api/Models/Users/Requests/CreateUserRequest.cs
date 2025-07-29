using System.ComponentModel.DataAnnotations;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models.Users.Requests;

/// <summary>
/// API-запрос создания <see cref="User"/>
/// </summary>
public class CreateUserRequest
{
    [Required, EmailAddress] public required string Email { get; init; }

    [Required, StringLength(200, MinimumLength = 2)]
    public required string Name { get; init; }

    [Required, StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Password)]
    public required string Password { get; init; }
}
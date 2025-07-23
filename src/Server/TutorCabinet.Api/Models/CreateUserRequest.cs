using System.ComponentModel.DataAnnotations;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models;

/// <summary>
/// API-запрос создания <see cref="User"/>
/// </summary>
public class CreateUserRequest
{
    [Required, EmailAddress] public string Email { get; set; }

    [Required, StringLength(200, MinimumLength = 2)]
    public string Name { get; set; }

    [Required, StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
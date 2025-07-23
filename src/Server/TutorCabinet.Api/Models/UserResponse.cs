using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models;

/// <summary>
/// Ответ API с данными <see cref="User"/>
/// </summary>
public class UserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models;

/// <summary>
/// Ответ API с данными <see cref="User"/>
/// </summary>
public class UserResponse
{
    public Guid Id { get; init; }
    public required string Email { get; init; }
    public required string Name { get; init; }
}
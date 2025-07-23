namespace TutorCabinet.Application.DTOs;

/// <summary>
/// DTO пользователя
/// </summary>
public class UserDto
{
    public Guid Id { get; init; }
    public required string Email { get; init; }
    public required string Name { get; init; }
}
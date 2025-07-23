namespace TutorCabinet.Application.DTOs;

/// <summary>
/// DTO пользователя
/// </summary>
public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
}
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.DTOs;

/// <summary>
/// DTO, содержащий данные для создания нового <see cref="User"/>
/// </summary>
public class CreateUserDto
{
    public required string Email { get; init; }
    public required string Name { get; init; }
    public required string Password { get; init; }
}
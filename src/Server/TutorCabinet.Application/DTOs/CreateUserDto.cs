using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.DTOs;

/// <summary>
/// DTO, содержащий данные для создания нового <see cref="User"/>
/// </summary>
public class CreateUserDto
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}
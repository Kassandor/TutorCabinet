using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.DTOs;

/// <summary>
/// DTO, содержащий данные для обновления <see cref="User"/>
/// </summary>
public class UpdateUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}
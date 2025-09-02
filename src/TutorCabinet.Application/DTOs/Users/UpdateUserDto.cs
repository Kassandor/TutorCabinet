using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.DTOs;

/// <summary>
/// DTO, содержащий данные для обновления <see cref="User"/>
/// </summary>
public class UpdateUserDto
{
    public Guid Id { get; init; }
    public required string Email { get; init; }
    public required string Name { get; init; }
}

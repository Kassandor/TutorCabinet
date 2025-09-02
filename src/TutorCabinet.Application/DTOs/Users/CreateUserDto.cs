using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.DTOs.Users;

/// <summary>
/// DTO, содержащий данные для создания нового <see cref="User"/>
/// </summary>
public sealed record CreateUserDto(string Email, string Name, string Password);

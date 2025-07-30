using TutorCabinet.Core.Entities;

namespace TutorCabinet.Application.DTOs;

/// <summary>
/// DTO, содержащий данные для создания нового <see cref="User"/>
/// </summary>
public sealed record CreateUserDto(string Email, string Name, string Password);
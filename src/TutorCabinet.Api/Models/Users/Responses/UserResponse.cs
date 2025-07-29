using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models.Users.Responses;

/// <summary>
/// Ответ API с данными <see cref="User"/>
/// </summary>
public sealed record UserResponse(Guid Id, string Email, string Name);

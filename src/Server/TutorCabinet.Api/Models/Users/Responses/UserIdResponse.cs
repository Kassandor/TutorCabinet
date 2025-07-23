using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models.Users.Responses;

/// <summary>
/// Ответ API с <see cref="Guid"/> пользователя <see cref="User"/>
/// </summary>
/// <param name="Id"><see cref="Guid"/></param>
public sealed record UserIdResponse(Guid Id);
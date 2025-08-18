using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models.Users.Responses;

/// <summary>
/// Ответ API, содержащий коллекцию всех пользователей <see cref="User"/>.
/// </summary>
/// <param name="Users">Список пользователей в формате <see cref="UserResponse"/>.</param>
/// <param name="TotalCount">Общее количество пользователей в базе данных.</param>
public sealed record AllUsersResponse(List<UserResponse> Users, int TotalCount);

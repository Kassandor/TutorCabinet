using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models.Students.Responses;

/// <summary>
/// Ответ API, содержащий коллекцию всех <see cref="Student"/>.
/// </summary>
/// <param name="Students">Список пользователей в формате <see cref="StudentResponse"/>.</param>
/// <param name="TotalCount">Общее количество пользователей в базе данных.</param>
public sealed record AllStudentsResponse(List<StudentResponse> Students, int TotalCount);

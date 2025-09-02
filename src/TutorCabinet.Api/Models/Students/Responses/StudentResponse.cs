using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models.Students.Responses;

/// <summary>
/// Ответ API с данными <see cref="Student"/>
/// </summary>
public sealed record StudentResponse(Guid Id, string Name, int ClassNumber, Guid DirectionStudyId);

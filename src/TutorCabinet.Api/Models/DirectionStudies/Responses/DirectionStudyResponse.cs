using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models.DirectionStudies.Responses;

/// <summary>
/// Ответ API с данными <see cref="DirectionStudy"/>
/// </summary>
public sealed record DirectionStudyResponse(Guid Id, string Name);

using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models.DirectionStudies.Responses;

/// <summary>
/// Ответ API, содержащий коллекцию всех <see cref="DirectionStudy"/>.
/// </summary>
/// <param name="DirectionStudies">Список объектов в формате <see cref="DirectionStudyResponse"/>.</param>
/// <param name="TotalCount">Общее количество объектов в базе данных.</param>
public sealed record AllDirectionStudiesResponse(
    List<DirectionStudyResponse> DirectionStudies,
    int TotalCount
);

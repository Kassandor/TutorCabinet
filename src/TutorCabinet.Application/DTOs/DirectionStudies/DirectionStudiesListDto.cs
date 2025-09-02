namespace TutorCabinet.Application.DTOs.DirectionStudies;

public sealed record DirectionStudiesListDto(
    List<DirectionStudyDto> DirectionStudies,
    int TotalCount
);

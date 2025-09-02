namespace TutorCabinet.Application.DTOs.Students;

public sealed record StudentDto(Guid Id, string Name, int ClassNumber, Guid DirectionStudyId);

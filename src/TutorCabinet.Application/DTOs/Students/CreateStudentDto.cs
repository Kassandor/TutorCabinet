namespace TutorCabinet.Application.DTOs.Students;

public sealed record CreateStudentDto(string Name, int ClassNumber, Guid DirectionStudyId);

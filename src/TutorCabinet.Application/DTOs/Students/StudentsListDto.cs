namespace TutorCabinet.Application.DTOs.Students;

public sealed record StudentsListDto(List<StudentDto> Students, int TotalCount);

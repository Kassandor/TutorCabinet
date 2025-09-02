using System.ComponentModel.DataAnnotations;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models.Students.Requests;

/// <summary>
/// API-запрос создания <see cref="Student"/>
/// </summary>
public class CreateStudentRequest
{
    [Required, StringLength(100, MinimumLength = 2)]
    public required string Name { get; init; }

    [Required]
    public required int ClassNumber { get; init; }

    [Required]
    public required Guid DirectionStudyId { get; init; }
}

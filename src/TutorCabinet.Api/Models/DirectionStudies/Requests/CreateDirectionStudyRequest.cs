using System.ComponentModel.DataAnnotations;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Models.DirectionStudies.Requests;

/// <summary>
/// API-запрос создания <see cref="DirectionStudy"/>
/// </summary>
public class CreateDirectionStudyRequest
{
    [Required, StringLength(100, MinimumLength = 2)]
    public required string Name { get; init; }
}

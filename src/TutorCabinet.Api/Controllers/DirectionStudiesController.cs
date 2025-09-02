using Microsoft.AspNetCore.Mvc;
using TutorCabinet.Api.Models.Common;
using TutorCabinet.Api.Models.DirectionStudies.Requests;
using TutorCabinet.Api.Models.DirectionStudies.Responses;
using TutorCabinet.Api.Models.Students.Responses;
using TutorCabinet.Application.DTOs.DirectionStudies;
using TutorCabinet.Application.Interfaces.Services;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Controllers;

[ApiController]
[Route("api/direction_studies")]
public class DirectionStudiesController(IDirectionStudyService studyService) : ControllerBase
{
    /// <summary>
    /// API для создания <see cref="DirectionStudy"/> по id
    /// </summary>
    /// <param name="req"><see cref="CreateDirectionStudyRequest"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> Create(
        [FromBody] CreateDirectionStudyRequest req,
        CancellationToken cancellationToken
    )
    {
        var dto = new CreateDirectionStudyDto(req.Name);
        var newId = await studyService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = newId }, new IdResponse(newId));
    }

    /// <summary>
    /// API для получения <see cref="DirectionStudy"/> по переданному id
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DirectionStudyResponse>> Get(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        if (await studyService.GetByIdAsync(id, cancellationToken) is not { } dto)
            return NotFound();
        return Ok(new DirectionStudyResponse(dto.Id, dto.Name));
    }

    /// <summary>
    /// API для получения всех <see cref="DirectionStudy"/>
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<AllStudentsResponse>> GetAll(CancellationToken cancellationToken)
    {
        if (await studyService.GetAllAsync(cancellationToken) is not { } studiesDto)
            return NotFound();
        var studies = studiesDto
            .DirectionStudies.Select(dto => new DirectionStudyResponse(dto.Id, dto.Name))
            .ToList();
        return Ok(new AllDirectionStudiesResponse(studies, studiesDto.TotalCount));
    }
}

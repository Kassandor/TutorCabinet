using Microsoft.AspNetCore.Mvc;
using TutorCabinet.Api.Models.Common;
using TutorCabinet.Api.Models.Students.Requests;
using TutorCabinet.Api.Models.Students.Responses;
using TutorCabinet.Application.DTOs.Students;
using TutorCabinet.Application.Interfaces.Services;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController(IStudentService studentService) : ControllerBase
{
    /// <summary>
    /// API для создания <see cref="Student"/> по id
    /// </summary>
    /// <param name="req"><see cref="CreateStudentDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> Create(
        [FromBody] CreateStudentRequest req,
        CancellationToken cancellationToken
    )
    {
        var dto = new CreateStudentDto(req.Name, req.ClassNumber, req.DirectionStudyId);
        var newId = await studentService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = newId }, new IdResponse(newId));
    }

    /// <summary>
    /// API для получения <see cref="Student"/> по переданному id
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StudentResponse>> Get(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        if (await studentService.GetByIdAsync(id, cancellationToken) is not { } dto)
            return NotFound();
        return Ok(new StudentResponse(dto.Id, dto.Name, dto.ClassNumber, dto.DirectionStudyId));
    }

    /// <summary>
    /// API для получения всех <see cref="Student"/>
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<AllStudentsResponse>> GetAll(CancellationToken cancellationToken)
    {
        if (await studentService.GetAllAsync(cancellationToken) is not { } studentsDto)
            return NotFound();
        var students = studentsDto
            .Students.Select(dto => new StudentResponse(
                dto.Id,
                dto.Name,
                dto.ClassNumber,
                dto.DirectionStudyId
            ))
            .ToList();
        return Ok(new AllStudentsResponse(students, studentsDto.TotalCount));
    }
}

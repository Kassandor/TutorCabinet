using Microsoft.AspNetCore.Mvc;
using TutorCabinet.Api.Models;
using TutorCabinet.Application.DTOs;
using TutorCabinet.Application.Interfaces;
using TutorCabinet.Core.Entities;

namespace TutorCabinet.Api.Controllers;

/// <summary>
/// Контроллер для сущности <see cref="User"/>
/// </summary>
/// <param name="userService"><see cref="IUserService"/></param>
[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    /// <summary>
    /// API для получения <see cref="User"/> по переданному id
    /// </summary>
    /// <param name="id"><see cref="Guid"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserResponse>> Get(Guid id, CancellationToken cancellationToken)
    {
        var dto = await userService.GetByIdAsync(id, cancellationToken);
        if (dto is null) return NotFound();
        return Ok(new UserResponse
        {
            Id = dto.Id,
            Email = dto.Email,
            Name = dto.Name
        });
    }

    /// <summary>
    /// API для создания <see cref="User"/> по id
    /// </summary>
    /// <param name="req"><see cref="CreateUserDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateUserRequest req, CancellationToken cancellationToken)
    {
        var dto = new CreateUserDto
        {
            Email = req.Email, Name = req.Name, Password = req.Password
        };
        var newId = await userService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = newId }, null);
    }
}
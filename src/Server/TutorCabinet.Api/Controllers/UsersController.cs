using Microsoft.AspNetCore.Mvc;
using TutorCabinet.Api.Models;
using TutorCabinet.Application.DTOs;
using TutorCabinet.Application.Interfaces;

namespace TutorCabinet.Api.Controllers;

public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserResponse>> Get(Guid id, CancellationToken cancellationToken)
    {
        var dto = await userService.GetByIdAsync(id, cancellationToken);
        if (dto == null) return NotFound();
        return Ok(new UserResponse
        {
            Id = dto.Id,
            Email = dto.Email,
            Name = dto.Name
        });
    }

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
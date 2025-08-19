using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorCabinet.Api.Models.Users.Requests;
using TutorCabinet.Api.Models.Users.Responses;
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
    /// API для создания <see cref="User"/> по id
    /// </summary>
    /// <param name="req"><see cref="CreateUserDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> Create(
        [FromBody] CreateUserRequest req,
        CancellationToken cancellationToken
    )
    {
        var dto = new CreateUserDto(req.Email, req.Name, req.Password);
        var newId = await userService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = newId }, new UserIdResponse(newId));
    }

    /// <summary>
    /// API для получения всех <see cref="User"/>
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<AllUsersResponse>> GetAll(CancellationToken cancellationToken)
    {
        var usersListDto = await userService.GetAllAsync(cancellationToken);

        if (usersListDto is null)
            return NotFound();

        // Маппим UserDto в UserResponse
        var users = usersListDto
            .Users.Select(dto => new UserResponse(dto.Id, dto.Email, dto.Name))
            .ToList();

        return Ok(new AllUsersResponse(users, usersListDto.TotalCount));
    }

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
        if (dto is null)
            return NotFound();
        return Ok(new UserResponse(dto.Id, dto.Email, dto.Name));
    }

    /// <summary>
    /// API для получения данных <see cref="User"/>, которые будут отображаться в профиле пользователя
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<UserResponse>> GetMe(CancellationToken cancellationToken)
    {
        var dto = await userService.GetByCurrentUserAsync(User, cancellationToken);
        if (dto is null)
            return NotFound();
        return Ok(new UserResponse(dto.Id, dto.Email, dto.Name));
    }
}

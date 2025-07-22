using Microsoft.AspNetCore.Mvc;
using TutorCabinet.Api.Models;
using TutorCabinet.Application.DTOs;
using TutorCabinet.Application.Interfaces;

namespace TutorCabinet.Api.Controllers;

/// <summary>
/// Контроллер для сущности User
/// </summary>
/// <param name="userService">Сервис пользователя</param>
[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    /// <summary>
    /// Получение пользователя по id
    /// </summary>
    /// <param name="id">guid</param>
    /// <param name="cancellationToken">Токен отмены</param>
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
    /// Создание пользователя
    /// </summary>
    /// <param name="req">Request DTO</param>
    /// <param name="cancellationToken">Токен отмены</param>
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
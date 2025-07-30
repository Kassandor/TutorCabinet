using Microsoft.AspNetCore.Mvc;
using TutorCabinet.Api.Models.Users.Requests;
using TutorCabinet.Application.DTOs;
using TutorCabinet.Application.Interfaces;

namespace TutorCabinet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AuthUserRequest req, CancellationToken cancellationToken)
    {
        var dto = new AuthUserDto(req.Email, req.Password);
        var token = await authService.LoginAsync(dto, cancellationToken);
        if (token is null) return Unauthorized();
        return Ok(token);
    }
}
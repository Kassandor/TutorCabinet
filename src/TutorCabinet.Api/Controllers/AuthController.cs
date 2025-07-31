using Microsoft.AspNetCore.Mvc;
using TutorCabinet.Api.Models.Auth.Requests;
using TutorCabinet.Api.Models.Auth.Respones;
using TutorCabinet.Application.DTOs;
using TutorCabinet.Application.Interfaces;

namespace TutorCabinet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    /// <summary>
    /// Контроллер формы входа пользователя
    /// </summary>
    /// <param name="req"><see cref="AuthUserRequest"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<AuthUserResponse>> Login([FromBody] AuthUserRequest req,
        CancellationToken cancellationToken)
    {
        var dto = new AuthUserDto(req.Email, req.Password);
        var tokenPair = await authService.LoginAsync(dto, cancellationToken);
        if (tokenPair is null) return Unauthorized();
        return Ok(new AuthUserResponse(tokenPair));
    }

    /// <summary>
    /// Контроллер обновления JWT токенов
    /// </summary>
    /// <param name="req"><see cref="RefreshTokensRequest"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpPost("refresh")]
    public async Task<ActionResult<AuthUserResponse>> Refresh([FromBody] RefreshTokensRequest req,
        CancellationToken cancellationToken)
    {
        var dto = new RefreshTokenDto(req.Email, req.RefreshToken);
        var newTokens = await authService.RefreshTokenAsync(dto, cancellationToken);
        if (newTokens is null) return Unauthorized();
        return Ok(new AuthUserResponse(newTokens));
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorCabinet.Application.Interfaces;

namespace TutorCabinet.Api.Controllers;

[ApiController]
[Route("api/index")]
[Authorize]
public class IndexController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetIndexPage(CancellationToken cancellationToken)
    {
        Console.WriteLine("GetIndexPage");
        if (await userService.UserExistsByClaimsAsync(User, cancellationToken))
            return Ok();
        return Unauthorized();
    }
}

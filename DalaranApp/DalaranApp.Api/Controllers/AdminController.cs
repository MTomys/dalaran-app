using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[Route("admin")]
[Authorize(Roles = "Admin")]
public class AdminController : ApiControllerBase
{
    private readonly ISender _mediator;

    public AdminController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("/GetPlebRequests")]
    public async Task<IActionResult> GetPlebRequests()
    {
        await Task.CompletedTask;
        var user = HttpContext.User.Identity;
        

        return Ok();
    }
}
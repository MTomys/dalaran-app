using DalaranApp.Application.Auth.Queries;
using DalaranApp.Application.Plebs.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthController : ApiControllerBase
{
    private readonly ISender _mediator;

    public AuthController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery loginQuery)
    {
        var response = await _mediator.Send(loginQuery);
        if (response == null)
        {
            return Unauthorized();
        }
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
    {
        var response = await _mediator.Send(registerCommand);
        return Ok(response);
    }
}
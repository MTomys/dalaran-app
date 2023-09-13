using DalaranApp.Application.Bajs.Commands;
using DalaranApp.Application.ExtensionMethods;
using DalaranApp.Contracts.NewcomerBajs;
using DalaranApp.Domain.Auth.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[Route("newcomerbaj")]
[Authorize(Roles = Roles.NewcomerBaj)]
public class NewcomerBajController : ApiControllerBase
{
    private readonly ISender _mediator;

    public NewcomerBajController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterBaj(
        [FromBody] CreateBajAccountRequest createBajAccountRequest)
    {
        var newcomerBajMemberId = HttpContext.User.GetIdFromNameIdentifier();

        var registerNewBajCommand =
            new RegisterNewcomerBajCommand(newcomerBajMemberId, createBajAccountRequest.NewcomerBajProfileName);

        var authResponse = await _mediator.Send(registerNewBajCommand);
        return Ok(authResponse);
    }
}
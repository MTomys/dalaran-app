using DalaranApp.Application.Admins.Queries;
using DalaranApp.Application.ExtensionMethods;
using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.Auth.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[Route("admin")]
[Authorize(Roles = Roles.Admin)]
public class AdminController : ApiControllerBase
{
    private readonly ISender _mediator;

    public AdminController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("/admin/plebs")]
    public async Task<IActionResult> GetPlebRequests()
    {
        await Task.CompletedTask;

        var adminId = HttpContext.User.GetIdFromNameIdentifier();
        var getPlebsQuery = new GetPlebsQuery(adminId);

        var result = await _mediator.Send(getPlebsQuery);

        return Ok(result);
    }

    [HttpPost]
    [Route("/admin/plebs/decision")]
    public async Task<IActionResult> CreatePlebsDecision([FromBody] Decision decision)
    {
        await Task.CompletedTask;

        return Ok();
    }
}
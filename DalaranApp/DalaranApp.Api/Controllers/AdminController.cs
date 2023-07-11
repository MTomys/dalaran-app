using System.Net;
using DalaranApp.Application.Admins.Commands;
using DalaranApp.Application.Admins.Queries;
using DalaranApp.Application.ExtensionMethods;
using DalaranApp.Contracts.Admins.Decisions;
using DalaranApp.Contracts.Admins.PlebRequests.Responses;
using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.Auth.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[Route("admin")]
[Authorize(Roles = Roles.Admin)]
public class AdminController : ApiControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AdminController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("/admin/plebs")]
    [ProducesResponseType(typeof(IEnumerable<GetPlebRequestResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetPlebRequests()
    {
        var adminId = HttpContext.User.GetIdFromNameIdentifier();
        var getPlebsQuery = new GetPlebsQuery(adminId);

        var result = await _mediator.Send(getPlebsQuery);

        var response = result
            .Select(plebRequest => _mapper.Map<GetPlebRequestResponse>(plebRequest));

        return Ok(response);
    }

    [HttpPost]
    [Route("/admin/plebs/decision")]
    public async Task<IActionResult> CreatePlebsDecisions(
        [FromBody] List<CreatePlebsDecisionsRequest> decisionsRequest)
    {
        var adminId = HttpContext.User.GetIdFromNameIdentifier();
        var decisionsRequestList = decisionsRequest.ToList();

        decisionsRequestList
            .ForEach(decision => decision.AdminId = adminId);

        var decisions = decisionsRequestList
            .Select(decision => _mapper.Map<Decision>(decision));

        var plebDecisionsCommand = new PlebDecisionsCommand(decisions);
        await _mediator.Send(plebDecisionsCommand);

        return Ok();
    }
}
using System.Net;
using DalaranApp.Application.Bajs.Queries;
using DalaranApp.Application.ExtensionMethods;
using DalaranApp.Contracts.Bajs.Contacts.Responses;
using DalaranApp.Domain.Auth.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[Route("baj")]
[Authorize(Roles = Roles.Baj)]
public class BajController : ApiControllerBase
{
    private readonly ISender _mediator;

    public BajController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("contacts")]
    [ProducesResponseType(typeof(IEnumerable<BajContact>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBajContacts()
    {
        var bajId = User.GetIdFromNameIdentifier();
        var bajContactsQuery = new GetBajContactsQuery(bajId);
        var response = await _mediator.Send(bajContactsQuery);
        return Ok(response);
    }
}
using System.Collections;
using System.Net;
using DalaranApp.Application.Bajs.Queries;
using DalaranApp.Application.ExtensionMethods;
using DalaranApp.Contracts.Bajs.Contacts.Responses;
using DalaranApp.Contracts.Bajs.Me;
using DalaranApp.Domain.Auth.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[Route("bajs")]
[Authorize(Roles = Roles.Baj)]
public class BajController : ApiControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public BajController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{bajId:guid}/contacts")]
    [ProducesResponseType(typeof(IEnumerable<BajContactResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBajContacts(Guid bajId)
    {
        var userId = User.GetIdFromNameIdentifier();
        if (bajId != userId)
        {
            return Unauthorized();
        }
        var bajContactsQuery = new GetBajContactsQuery(User.GetIdFromNameIdentifier());

        var contacts = await _mediator.Send(bajContactsQuery);
        var response = _mapper.Map<IEnumerable<BajContactResponse>>(contacts);

        return Ok(response);
    }

    [HttpGet]
    [Route("{bajId:guid}/contacts/{contactId:guid}/messages")]
    [ProducesResponseType(typeof(IEnumerable<BajMessageResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBajMessages(Guid bajId, Guid contactId)
    {
        var userId = User.GetIdFromNameIdentifier();
        if (bajId != userId)
        {
            return Unauthorized();
        }
        var bajMessagesQuery = new GetBajMessagesQuery(bajId, contactId);
        var messages = await _mediator.Send(bajMessagesQuery);
        var response = _mapper.Map<IEnumerable<BajMessageResponse>>(messages);
        return Ok(response);
    }

    [HttpGet]
    [Route("me")]
    [ProducesResponseType(typeof(BajMeResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetMe()
    {
        var getBajMeQuery = new GetBajMeQuery(User.GetIdFromNameIdentifier());
        var response = _mapper.Map<BajMeResponse>(
            await _mediator.Send(getBajMeQuery)
        );
        return Ok(response);
    }
}
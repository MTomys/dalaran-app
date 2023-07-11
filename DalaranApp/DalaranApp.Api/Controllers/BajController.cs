using System.Collections;
using System.Net;
using DalaranApp.Application.Bajs.Queries;
using DalaranApp.Application.ExtensionMethods;
using DalaranApp.Contracts.Bajs.Contacts.Responses;
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
    public async Task<IActionResult> GetBajContacts(string bajId)
    {
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
        var bajMessagesQuery = new GetBajMessagesQuery(bajId, contactId);
        var messages = await _mediator.Send(bajMessagesQuery);
        var response = _mapper.Map<IEnumerable<BajMessageResponse>>(messages);
        return Ok(response);
    }
}
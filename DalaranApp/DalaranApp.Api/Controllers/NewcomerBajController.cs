using DalaranApp.Contracts.NewcomerBajs;
using DalaranApp.Domain.Auth.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[Route("newcomerbaj")]
[Authorize(Roles = Roles.NewcomerBaj)]
public class NewcomerBajController : ApiControllerBase
{
    [HttpPost]
    [Route("register")]
    public IActionResult RegisterBaj(
        [FromBody] CreateBajAccountRequest createBajAccountRequest)
    {
        // TODO: 
        return Ok();
    }
}
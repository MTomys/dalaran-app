using DalaranApp.Domain.Auth.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[Route("baj")]
[Authorize(Roles = Roles.Baj)]
public class BajController : ApiControllerBase
{
    [HttpGet]
    [Route("/test")]
    public IActionResult GetTest() => Ok("Hello");
}
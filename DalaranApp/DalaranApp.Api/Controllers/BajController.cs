using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[Route("baj")]
[Authorize(Roles = "baj")]
public class BajController : ApiControllerBase
{
    [HttpGet]
    [Route("/test")]
    public IActionResult GetTest() => Ok("Hello");
}
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[Route("test")]
public class TestController : ApiControllerBase
{
    [HttpGet]
    public IActionResult TestGet()
    {
        return Ok("hello!");
    }
}
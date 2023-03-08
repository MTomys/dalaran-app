using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

[ApiController]
[Authorize]
public class ApiControllerBase : ControllerBase
{
   
}
using System.Net;
using DalaranApp.Application.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DalaranApp.Api.Controllers;

public class ErrorController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        
        HttpStatusCode statusCode;
        string message;

        if (exception is IServiceException serviceException)
        {
            statusCode = serviceException.HttpStatusCode;
            message = serviceException.ErrorMessage;
        }
        else
        {
            statusCode = HttpStatusCode.InternalServerError;
            message = exception?.Message ?? "An unexpected error occured";
        }

        return Problem(statusCode: (int)statusCode, title: message);
    }
    
}
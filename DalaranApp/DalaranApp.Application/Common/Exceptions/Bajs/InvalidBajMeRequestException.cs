using System.Net;

namespace DalaranApp.Application.Common.Exceptions.Bajs;

public class InvalidBajMeRequestException : Exception, IServiceException
{
    public HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
    public string ErrorMessage => "Could not fetch 'me' details for non-baj member";
}
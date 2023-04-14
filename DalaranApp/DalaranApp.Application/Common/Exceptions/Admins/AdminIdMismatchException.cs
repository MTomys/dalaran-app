using System.Net;

namespace DalaranApp.Application.Common.Exceptions.Admins;

public class AdminIdMismatchException : Exception, IServiceException
{
    public HttpStatusCode HttpStatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "The admin id issuing the request does not match identity ID";
}
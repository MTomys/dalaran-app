using System.Net;

namespace DalaranApp.Application.Common.Exceptions.Bajs;

public class BajUsernameAlreadyTakenException : Exception, IServiceException
{
    public HttpStatusCode HttpStatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Baj profile name already taken";
}
using System.Net;

namespace DalaranApp.Application.Common.Exceptions.Members;

public class InvalidMemberCredentialsException : Exception, IServiceException
{
    public HttpStatusCode HttpStatusCode => HttpStatusCode.Forbidden;
    public string ErrorMessage => "";
}
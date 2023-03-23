using System.Net;

namespace DalaranApp.Application.Common.Exceptions.Members;

public class AuthorizedMemberIdMissingException : Exception, IServiceException
{
    public HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
    public string ErrorMessage => "Could not get member ID from claims identity";
}
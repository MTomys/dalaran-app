using System.Net;

namespace DalaranApp.Application.Common.Exceptions.Members;

public class MemberAlreadyExistsException : Exception, IServiceException
{
    private string _username;
    
    public MemberAlreadyExistsException(string username)
    {
        _username = username;
    }
    
    public HttpStatusCode HttpStatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage
        => $"A member with the given username is already registered in the system {_username}";
}
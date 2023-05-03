using System.Net;

namespace DalaranApp.Application.Common;

public interface IServiceException 
{
    HttpStatusCode HttpStatusCode { get; }
    string ErrorMessage { get; }
}
using System.Security.Claims;
using DalaranApp.Application.Common.Exceptions.Members;

namespace DalaranApp.Application.ExtensionMethods;

public static class ClaimsIdentityExtensions
{
    public static string GetIdFromNameIdentifier(this ClaimsIdentity claims)
    {
        var id = claims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrEmpty(id))
        {
            throw new AuthorizedMemberIdMissingException();
        }

        return id;
    }
    
}
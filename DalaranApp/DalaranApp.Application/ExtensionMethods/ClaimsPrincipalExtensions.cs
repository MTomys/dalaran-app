using System.Security.Claims;
using DalaranApp.Application.Common.Exceptions.Members;

namespace DalaranApp.Application.ExtensionMethods;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetIdFromNameIdentifier(this ClaimsPrincipal claimsPrincipal)
    {
        ArgumentNullException.ThrowIfNull(claimsPrincipal);

        var id = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(id))
        {
            throw new AuthorizedMemberIdMissingException();
        }

        return Guid.Parse(id);
    }
}
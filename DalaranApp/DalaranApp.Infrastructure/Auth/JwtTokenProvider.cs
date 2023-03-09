using DalaranApp.Application.Common.Interfaces;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Entities;

namespace DalaranApp.Infrastructure.Auth;

public class JwtTokenProvider : IJwtTokenProvider
{
    public string Generate(Member member)
    {
        throw new NotImplementedException();
    }
}
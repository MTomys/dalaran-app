using DalaranApp.Domain.Auth;

namespace DalaranApp.Application.Common.Interfaces.Auth;

public interface IJwtTokenProvider
{
    string Generate(Member member);
}
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Entities;

namespace DalaranApp.Application.Common.Interfaces.Auth;

public interface IJwtTokenProvider
{
    string Generate(Member member);
}
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Entities;

namespace DalaranApp.Application.Common.Interfaces.Auth;

public interface IMemberRepository
{
    Member? GetByUsername(string username);
    void Save(Member member);
}
using DalaranApp.Domain.Auth;

namespace DalaranApp.Application.Common.Interfaces.Auth;

public interface IMemberRepository
{
    Member? GetByUsername(string username);
    void Save(Member member);
}
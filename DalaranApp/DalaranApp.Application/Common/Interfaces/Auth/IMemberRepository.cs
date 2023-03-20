using DalaranApp.Domain.Auth.Entities;

namespace DalaranApp.Application.Common.Interfaces.Auth;

public interface IMemberRepository
{
    Member? GetMember(string username, string password);
    void Save(Member member);
}
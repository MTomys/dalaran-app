using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Domain.Auth.Entities;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Members;

public class InMemoryMemberRepository : IMemberRepository
{
    private readonly List<Member> _members = new()
    {
        new Member("admin", "adminPassword", Roles.Admin),
        new Member("baj", "bajPassword", Roles.Baj),
    };

    public Member? GetMember(string username, string password)
    {
        return _members
            .FirstOrDefault(m => m.Username == username && m.Password == password);
    }

    public void Save(Member member)
    {
        _members.Add(member);
    }
}
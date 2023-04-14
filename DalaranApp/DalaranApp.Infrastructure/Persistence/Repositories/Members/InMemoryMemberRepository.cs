using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Members;

public class InMemoryMemberRepository : IMemberRepository
{
    private readonly List<Member> _members = new()
    {
        new Member(
            Guid.Parse("00000000-1234-0000-0000-000000000000"),
            "admin",
            "admin",
            Roles.Admin),
        new Member(
            Guid.Parse("00000000-1235-0000-0000-000000000000"),
            "baj",
            "baj",
            Roles.Admin),
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
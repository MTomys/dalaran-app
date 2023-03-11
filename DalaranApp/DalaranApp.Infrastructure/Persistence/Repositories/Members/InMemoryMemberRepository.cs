using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth.Entities;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Members;

public class InMemoryMemberRepository : IMemberRepository
{
    private readonly List<Member> _members = new();

    public Member? GetByUsername(string username)
    {
        return _members
            .FirstOrDefault(member => member.Username == username);
    }

    public void Save(Member member)
    {
        _members.Add(member);
    }
}
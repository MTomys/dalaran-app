using DalaranApp.Application.Common.Exceptions.Members;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth;

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
        if (_members.Any(m => m.Username == member.Username))
        {
            throw new MemberAlreadyExistsException(member.Username);
        }
        _members.Add(member);
    }
}
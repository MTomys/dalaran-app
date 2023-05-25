using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Infrastructure.DataSeed;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Members;

public class InMemoryMemberRepository : IMemberRepository
{
    private readonly List<Member> _members = MemberDataSeed.GenerateMembers();

    public Member? GetByUsernameAndPassword(string username, string password)
    {
        return _members
            .FirstOrDefault(m => m.Username == username && m.Password == password);
    }

    public Member GetById(Guid id)
    {
        return _members.First(m => m.Id == id);
    }

    public Member Save(Member member)
    {
        _members.Add(member);
        return member;
    }

    public void Delete(Guid id)
    {
        var member = GetById(id);
        _members.Remove(member);
    }
}
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Members;

public class InMemoryMemberRepository : IMemberRepository
{
    private readonly List<Member> _members = new()
    {
        Member.Create(
            Guid.Parse("00000000-1235-0000-0000-000000000000"),
            "admin",
            "admin",
            Roles.Admin),
        Member.Create(
            Guid.Parse("00000000-1235-0000-0000-000000000000"),
            "baj",
            "baj",
            Roles.Admin),
        Member.Create(
            Guid.Parse("00000000-1236-0000-0000-000000000000"),
            "newcomerbaj",
            "newcomerbaj",
            Roles.NewcomerBaj),
    };

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
}
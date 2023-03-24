using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Domain.Auth.Entities;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Members;

public class InMemoryMemberRepository : IMemberRepository
{
    private readonly List<Member> _members = new()
    {
        new Member
        {
            Id = Guid.Parse("00000000-1234-0000-0000-000000000000"),
            Username = "admin",
            Password = "adminPassword",
            Role = Roles.Admin
        },
        new Member
        {
            Username = "baj",
            Password = "bajPassword",
            Role = Roles.Baj
        }
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
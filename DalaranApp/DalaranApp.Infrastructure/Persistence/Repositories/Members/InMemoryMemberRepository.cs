using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth.Entities;
using DalaranApp.Domain.Auth.Enums;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Members;

public class InMemoryMemberRepository : IMemberRepository
{
    private readonly List<Member> _members = new()
    {
        new Member
        {
            Username = "admin",
            Password = "adminPassword",
            Role = Role.Admin,
        },
        new Member
        {
            Username = "baj",
            Password = "bajPassword",
            Role = Role.Baj
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
using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Auth;

public class Member : AggregateRoot<Guid>
{
    public string Username { get; }
    public string Password { get; } 
    public string Role { get; } 

    private Member(Guid id, string username, string password, string role) : base(id)
    {
        Username = username;
        Password = password;
        Role = role;
    }

    public static Member Create(Guid id, string username, string password, string role)
    {
        return new Member(id, username, password, role);
    }
}
using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Auth;

public class Member : AggregateRoot<Guid>
{
    public string Username { get; } = string.Empty;
    public string Password { get; } = string.Empty;
    public string Role { get; } = string.Empty;

    public Member(Guid id, string username, string password, string role) : base(id)
    {
        Username = username;
        Password = password;
        Role = role;
    }
}
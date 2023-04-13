namespace DalaranApp.Domain.Auth.Entities;

public class Member
{
    public Guid Id { get; }
    public string Username { get; } = string.Empty;
    public string Password { get; } = string.Empty;
    public string Role { get; } = string.Empty;

    public Member(string username, string password, string role)
    {
        Id = Guid.NewGuid(); 
        Username = username;
        Password = password;
        Role = role;
    }
}
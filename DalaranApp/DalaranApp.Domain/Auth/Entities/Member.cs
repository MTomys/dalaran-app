using DalaranApp.Domain.Auth.Enums;

namespace DalaranApp.Domain.Auth.Entities;

public class Member
{
    public Guid Id { get; } = new Guid();
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public List<Role> Roles { get; set; } = new List<Role>();
}
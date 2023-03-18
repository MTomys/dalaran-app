using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Admins;

public class Admin : AggregateRoot<Guid>
{
    private readonly List<Guid> _plebIds;
    public string Username { get; set; }
    public string Password { get; set; }
    
    private Admin(){}
    
    
}
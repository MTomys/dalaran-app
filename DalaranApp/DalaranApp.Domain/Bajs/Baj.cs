using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Bajs;

public class Baj : AggregateRoot<Guid>
{
    public string ProfileName { get; }
    
}
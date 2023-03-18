using DalaranApp.Domain.Common.Interfaces;
using DalaranApp.Domain.Plebs;

namespace DalaranApp.Domain.DomainEvents;

public sealed record PlebRegisteredDomainEvent(Pleb Pleb) : IDomainEvent
{
    
}
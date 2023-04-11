using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.Common.Interfaces;

namespace DalaranApp.Domain.DomainEvents;

public sealed record PlebAcceptedDomainEvent(Decision Decision) : IDomainEvent;
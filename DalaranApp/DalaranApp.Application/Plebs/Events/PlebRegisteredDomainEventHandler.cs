using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Domain.DomainEvents;
using MediatR;

namespace DalaranApp.Application.Plebs.Events;

public sealed class PlebRegisteredDomainEventHandler : INotificationHandler<PlebRegisteredDomainEvent>
{
    private readonly IAdminRepository _adminRepository;
    
    public async Task Handle(PlebRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
    }
}
using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.DomainEvents;
using MediatR;

namespace DalaranApp.Application.Plebs.Events;

public sealed class PlebRegisteredDomainEventHandler : INotificationHandler<PlebRegisteredDomainEvent>
{
    private readonly IAdminRepository _adminRepository;

    public PlebRegisteredDomainEventHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task Handle(PlebRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var pleb = notification.Pleb;
        var plebRegistrationRequest = new PlebRegistrationRequest(pleb.Id, pleb.RegistrationRequest);

        var admins = _adminRepository.GetAdmins();
        admins.ForEach(admin => admin.AddPlebRequest(plebRegistrationRequest));
    }
}
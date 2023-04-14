using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Application.Common.Interfaces.Plebs;
using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.DomainEvents;
using MediatR;

namespace DalaranApp.Application.Plebs.Events;

public sealed class PlebRegisteredDomainEventHandler : INotificationHandler<PlebRegisteredDomainEvent>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IPlebRepository _plebRepository;

    public PlebRegisteredDomainEventHandler(IAdminRepository adminRepository, IPlebRepository plebRepository)
    {
        _adminRepository = adminRepository;
        _plebRepository = plebRepository;
    }

    public async Task Handle(PlebRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var pleb = notification.Pleb;
        var plebRegistrationRequest =
            new PlebRegistrationRequest(pleb.Id, pleb.RegistrationRequest, isAccepted: false);
        
        _plebRepository.Save(pleb);

        var admins = _adminRepository.GetAdmins();
        admins.ForEach(admin => admin.AddPlebRequest(plebRegistrationRequest));
    }
}
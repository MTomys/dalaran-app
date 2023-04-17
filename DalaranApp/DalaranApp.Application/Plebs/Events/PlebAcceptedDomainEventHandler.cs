using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Plebs;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Domain.DomainEvents;
using DalaranApp.Domain.Plebs.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Plebs.Events;

public class PlebAcceptedDomainEventHandler : INotificationHandler<PlebAcceptedDomainEvent>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly IPlebRepository _plebRepository;

    public PlebAcceptedDomainEventHandler(IMemberRepository memberRepository, IAdminRepository adminRepository,
        IPlebRepository plebRepository)
    {
        _memberRepository = memberRepository;
        _adminRepository = adminRepository;
        _plebRepository = plebRepository;
    }

    public async Task Handle(PlebAcceptedDomainEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var decision = notification.Decision;

        var admin = _adminRepository.GetById(decision.AdminId);
        admin.AddDecision(decision);

        var pleb = _plebRepository.GetById(decision.PlebId);
        var registrationRequest = pleb.RegistrationRequest;

        var member = GetMemberFromRegistrationRequest(registrationRequest);
        _memberRepository.Save(member);
    }

    private Member GetMemberFromRegistrationRequest(RegistrationRequest registrationRequest)
    {
        var username = registrationRequest.RequestedUsername;
        var password = registrationRequest.RequestedPassword;
        return new Member(Guid.NewGuid(), username, password, Roles.NewcomerBaj);
    }
}
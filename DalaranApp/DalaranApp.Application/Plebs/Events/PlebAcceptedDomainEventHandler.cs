using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Domain.Auth.Entities;
using DalaranApp.Domain.DomainEvents;
using MediatR;

namespace DalaranApp.Application.Plebs.Events;

public class PlebAcceptedDomainEventHandler : INotificationHandler<PlebAcceptedDomainEvent>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IAdminRepository _adminRepository;

    public PlebAcceptedDomainEventHandler(IMemberRepository memberRepository, IBajRepository bajRepository,
        IAdminRepository adminRepository)
    {
        _memberRepository = memberRepository;
        _adminRepository = adminRepository;
    }

    public async Task Handle(PlebAcceptedDomainEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var decision = notification.Decision;

        var admin = _adminRepository.GetById(decision.AdminId);
        admin.AddDecision(decision);

        if (decision.IsAccepted)
        {
            var member = GetMemberFromRegistrationRequest(decision.PlebRegistrationRequest);
            _memberRepository.Save(member);
        }
    }

    private Member GetMemberFromRegistrationRequest(PlebRegistrationRequest plebRegistrationRequest)
    {
        var username = plebRegistrationRequest.RegistrationRequest.RequestedUsername;
        var password = plebRegistrationRequest.RegistrationRequest.RequestedPassword;
        return new Member(username, password, Roles.Baj);
    }
}
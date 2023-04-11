using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Domain.DomainEvents;
using MediatR;

namespace DalaranApp.Application.Plebs.Events;

public class PlebAcceptedDomainEventHandler : INotificationHandler<PlebAcceptedDomainEvent>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IBajRepository _bajRepository;

    public PlebAcceptedDomainEventHandler(IMemberRepository memberRepository, IBajRepository bajRepository)
    {
        _memberRepository = memberRepository;
        _bajRepository = bajRepository;
    }

    public async Task Handle(PlebAcceptedDomainEvent notification, CancellationToken cancellationToken)
    {
        var decision = notification.Decision;

    }
}
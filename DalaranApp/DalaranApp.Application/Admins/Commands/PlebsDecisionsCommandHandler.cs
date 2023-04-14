using DalaranApp.Application.Common.Exceptions.Admins;
using DalaranApp.Domain.DomainEvents;
using MediatR;

namespace DalaranApp.Application.Admins.Commands;

public class PlebsDecisionsCommandHandler : IRequestHandler<PlebDecisionsCommand>
{
    private readonly IPublisher _publisher;

    public PlebsDecisionsCommandHandler(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task Handle(PlebDecisionsCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var (issuingAdmin, decisions) = request;
        var decisionsList = decisions.ToList();

        if (decisionsList.Any(decision => decision.AdminId.ToString() != issuingAdmin))
        {
            throw new AdminIdMismatchException();
        }

        var positiveDecisions = decisionsList.Where(d => d.IsAccepted);

        foreach (var decision in positiveDecisions)
        {
            await _publisher.Publish(new PlebAcceptedDomainEvent(decision), cancellationToken);
        }
    }
}
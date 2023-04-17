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
        var decisions = request.Decisions;
        var decisionsList = decisions.ToList();

        var positiveDecisions = decisionsList.Where(d => d.IsAccepted);

        foreach (var decision in positiveDecisions)
        {
            await _publisher.Publish(new PlebAcceptedDomainEvent(decision), cancellationToken);
        }
    }
}
using MediatR;

namespace DalaranApp.Application.Admins.Commands;

public class PlebsDecisionCommandHandler : IRequestHandler<PlebsDecisionCommand>
{
    private readonly IPublisher _publisher;

    public PlebsDecisionCommandHandler(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public Task Handle(PlebsDecisionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
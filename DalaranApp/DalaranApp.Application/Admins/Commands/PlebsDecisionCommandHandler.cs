using MediatR;

namespace DalaranApp.Application.Admins.Commands;

public class PlebsDecisionCommandHandler : IRequestHandler<PlebsDecisionCommand>
{
    public async Task Handle(PlebsDecisionCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var plebRequests = request.PlebRequests;
        
        
    }
}
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Domain.Bajs.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Bajs.Commands;

public class AddMessageFromBajCommandHandler : IRequestHandler<AddMessageFromBajCommand>
{
    private readonly IBajRepository _bajRepository;

    public AddMessageFromBajCommandHandler(IBajRepository bajRepository)
    {
        _bajRepository = bajRepository;
    }

    public async Task Handle(AddMessageFromBajCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var baj = _bajRepository.GetById(request.BajId);
        var message = new Message(request.SenderId, request.ReceiverId, request.Content, request.SentAt);
        baj.AddMessage(message);
        _bajRepository.Update(baj);
    }
}
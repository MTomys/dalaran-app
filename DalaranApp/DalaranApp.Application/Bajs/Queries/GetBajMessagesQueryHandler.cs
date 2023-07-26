using DalaranApp.Application.Bajs.Common;
using DalaranApp.Application.Common.Interfaces.Bajs;
using MediatR;

namespace DalaranApp.Application.Bajs.Queries;

public record GetBajMessagesQueryHandler : IRequestHandler<GetBajMessagesQuery, IEnumerable<BajMessage>>
{
    private readonly IBajRepository _bajRepository;

    public GetBajMessagesQueryHandler(IBajRepository bajRepository)
    {
        _bajRepository = bajRepository;
    }

    public async Task<IEnumerable<BajMessage>> Handle(GetBajMessagesQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var baj = _bajRepository.GetById(request.BajId);
        var contact = _bajRepository.GetById(request.ContactId);

        var incomingMessages = baj.BajMessages
            .Where(m => m.SenderId == contact.Id)
            .Select(m => new BajMessage(contact.ProfileName, baj.ProfileName, m.Content, m.SentAt));

        var outgoingMessages = baj.BajMessages
            .Where(m => m.ReceiverId == contact.Id)
            .Select(m => new BajMessage(baj.ProfileName, contact.ProfileName, m.Content, m.SentAt));

        var allMessages = incomingMessages
            .Concat(outgoingMessages)
            .OrderBy(m => m.Timestamp);
        return allMessages;
    }
}
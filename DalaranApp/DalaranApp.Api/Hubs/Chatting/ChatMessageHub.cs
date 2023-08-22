using DalaranApp.Application.Bajs.Commands;
using DalaranApp.Contracts.Messaging;
using DalaranApp.Domain.Auth.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DalaranApp.Api.Hubs.Chatting;

[Authorize(Roles = Roles.Baj)]
public class ChatMessageHub : Hub<IChatMessageClient>
{
    public async Task SendMessage(
        SendMessageParams sendMessage,
        [FromServices] IMapper mapper,
        ISender mediator)
    {
        await Clients.Users(new []{sendMessage.RecipientId, sendMessage.SenderId})
            .ReceiveMessage(mapper.Map<ReceiveMessageParams>(sendMessage));
        var senderId = Guid.Parse(sendMessage.SenderId);
        var recipientId = Guid.Parse(sendMessage.RecipientId);
        
        var senderMessageCommand = new AddMessageFromBajCommand(
            BajId: senderId, senderId, recipientId, sendMessage.Content);
        var recipientMessageCommand = new AddMessageFromBajCommand(
            BajId: recipientId, senderId, recipientId, sendMessage.Content);
        
        await mediator.Send(senderId)
    }
}
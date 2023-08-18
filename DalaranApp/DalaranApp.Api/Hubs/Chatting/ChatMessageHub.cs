using DalaranApp.Contracts.Messaging;
using DalaranApp.Domain.Auth.Common;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DalaranApp.Api.Hubs.Chatting;

[Authorize(Roles = Roles.Baj)]
public class ChatMessageHub : Hub<IChatMessageClient>
{
    public async Task SendMessage(
        SendMessageParams sendMessage,
        [FromServices] IMapper mapper)
    {
        await Clients.All.ReceiveMessage(mapper.Map<ReceiveMessageParams>(sendMessage));
    }
}
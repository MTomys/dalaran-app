using DalaranApp.Contracts.Messaging;
using Microsoft.AspNetCore.SignalR;

namespace DalaranApp.Api.Hubs;

public class ChatMessageHub: Hub 
{
    public async Task SendMessage(MessageRequest message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
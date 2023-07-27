using DalaranApp.Contracts.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace DalaranApp.Api.Hubs;
    
[Authorize]
public class ChatMessageHub : Hub
{
    public async Task SendMessage(SendMessageParams sendMessage)
    {
        await Clients.All.SendAsync(
            "ReceiveMessage",
            new ReceiveMessageParams(sendMessage.Sender, sendMessage.Recipient, sendMessage.Content, DateTime.Now));
    }
}
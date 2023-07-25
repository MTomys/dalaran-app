using DalaranApp.Contracts.Messaging;
using Microsoft.AspNetCore.SignalR;

namespace DalaranApp.Api.Hubs;

public class ChatMessageHub : Hub
{
    public async Task SendMessage(SendMessageParams sendMessage)
    {
        await Clients.All.SendAsync(
            "ReceiveMessage",
            new ReceiveMessageParams(sendMessage.Sender, sendMessage.Receiver, sendMessage.Content, DateTime.Now));
    }
}
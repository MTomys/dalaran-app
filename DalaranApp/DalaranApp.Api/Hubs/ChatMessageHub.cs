using Microsoft.AspNetCore.SignalR;

namespace DalaranApp.Api.Hubs;

public class ChatMessageHub: Hub 
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
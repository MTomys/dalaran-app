using DalaranApp.Contracts.Messaging;

namespace DalaranApp.Api.Hubs.Chatting;

public interface IChatMessageClient
{
    Task ReceiveMessage(ReceiveMessageParams receiveMessageParams);
}
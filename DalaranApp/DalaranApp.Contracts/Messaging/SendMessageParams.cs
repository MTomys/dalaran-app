namespace DalaranApp.Contracts.Messaging;

public record SendMessageParams(string Sender, string Receiver, string Content);
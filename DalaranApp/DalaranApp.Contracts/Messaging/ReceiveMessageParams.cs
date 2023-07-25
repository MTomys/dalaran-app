namespace DalaranApp.Contracts.Messaging;

public record ReceiveMessageParams(string Sender, string Receiver, string Content, DateTime Timestamp);
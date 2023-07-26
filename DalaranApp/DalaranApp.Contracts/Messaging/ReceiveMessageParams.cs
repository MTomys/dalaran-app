namespace DalaranApp.Contracts.Messaging;

public record ReceiveMessageParams(string Sender, string Recipient, string Content, DateTime Timestamp);
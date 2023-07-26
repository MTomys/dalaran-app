namespace DalaranApp.Contracts.Messaging;

public record SendMessageParams(string Sender, string Recipient, string Content);
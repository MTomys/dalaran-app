namespace DalaranApp.Contracts.Messaging;

public record SendMessageParams(string Sender, string Recipient, string SenderId, string RecipientId, string Content);
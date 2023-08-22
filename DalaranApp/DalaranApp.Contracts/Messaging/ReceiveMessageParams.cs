namespace DalaranApp.Contracts.Messaging;

public record ReceiveMessageParams(
    string Sender,
    string Recipient,
    string SenderId,
    string RecipientId,
    string Content,
    DateTime Timestamp);
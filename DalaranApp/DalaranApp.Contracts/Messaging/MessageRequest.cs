namespace DalaranApp.Contracts.Messaging;

public record MessageRequest(string Sender, string Receiver, string Message);
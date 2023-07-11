namespace DalaranApp.Application.Bajs.Common;

public record BajMessage(string Sender, string Receiver, string Content, DateTime Timestamp);
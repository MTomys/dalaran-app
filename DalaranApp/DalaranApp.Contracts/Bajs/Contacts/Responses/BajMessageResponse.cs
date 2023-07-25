namespace DalaranApp.Contracts.Bajs.Contacts.Responses;

public record BajMessageResponse(string Sender, string Receiver, string Content, DateTime Timestamp);
namespace DalaranApp.Contracts.Bajs.Contacts.Responses;

public record BajMessageResponse(string SenderName, string ReceiverName, string Content, DateTime Timestamp);
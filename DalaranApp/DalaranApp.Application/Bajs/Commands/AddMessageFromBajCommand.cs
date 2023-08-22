namespace DalaranApp.Application.Bajs.Commands;

public record AddMessageFromBajCommand(Guid BajId, Guid SenderId, Guid ReceiverId, string Content);
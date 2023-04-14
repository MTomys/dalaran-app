namespace DalaranApp.Contracts.Admins.Decisions;

public record CreatePlebsDecisionsRequest
{
    public required string AdminId { get; set; }
    public required string PlebId { get; init; }
    public required bool IsAccepted { get; init; }
}
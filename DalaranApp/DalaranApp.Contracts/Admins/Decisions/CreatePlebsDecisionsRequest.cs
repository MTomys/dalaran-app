namespace DalaranApp.Contracts.Admins.Decisions;

public record CreatePlebsDecisionsRequest
{
    public Guid AdminId { get; set; }
    public string PlebId { get; init; }
    public bool IsAccepted { get; init; }
}
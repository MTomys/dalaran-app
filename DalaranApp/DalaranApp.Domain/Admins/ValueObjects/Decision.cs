using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Admins.ValueObjects;

public class Decision : ValueObject
{
    public Guid PlebId { get; }
    public DateTime DecidedAt { get; }
    public bool IsAccepted { get; }

    public Decision(Guid plebId, DateTime decidedAt, bool isAccepted)
    {
        PlebId = plebId;
        DecidedAt = decidedAt;
        IsAccepted = isAccepted;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return PlebId;
        yield return DecidedAt;
        yield return IsAccepted;
    }
}
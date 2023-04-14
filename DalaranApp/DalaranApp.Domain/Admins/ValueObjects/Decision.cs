using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Admins.ValueObjects;

public class Decision : ValueObject
{
    public Guid AdminId { get; }
    public Guid PlebId { get; }
    public DateTime DecidedAt { get; }
    public bool IsAccepted { get; }

    public Decision(Guid adminId, Guid plebId, DateTime decidedAt, bool isAccepted)
    {
        AdminId = adminId;
        PlebId = plebId;
        DecidedAt = decidedAt;
        IsAccepted = isAccepted;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return AdminId;
        yield return PlebId;
        yield return DecidedAt;
        yield return IsAccepted;
    }
}
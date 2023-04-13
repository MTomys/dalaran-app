using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Admins.ValueObjects;

public class Decision : ValueObject
{
    public Guid AdminId { get; }
    public PlebRegistrationRequest PlebRegistrationRequest { get; }
    public DateTime DecidedAt { get; }
    public bool IsAccepted { get; }

    public Decision(
        Guid adminId,
        PlebRegistrationRequest plebRegistrationRequest,
        DateTime decidedAt,
        bool isAccepted)
    {
        AdminId = adminId;
        PlebRegistrationRequest = plebRegistrationRequest;
        DecidedAt = decidedAt;
        IsAccepted = isAccepted;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return AdminId;
        yield return PlebRegistrationRequest;
        yield return DecidedAt;
        yield return IsAccepted;
    }
}
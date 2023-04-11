using DalaranApp.Domain.Common.Models;
using DalaranApp.Domain.Plebs.ValueObjects;

namespace DalaranApp.Domain.Admins.ValueObjects;

public class PlebRegistrationRequest : ValueObject
{
    public Guid PlebId { get; }
    public RegistrationRequest RegistrationRequest { get; }
    public bool IsAccepted { get; set; } = false;

    public PlebRegistrationRequest(Guid plebId, RegistrationRequest registrationRequest)
    {
        PlebId = plebId;
        RegistrationRequest = registrationRequest;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return PlebId;
        yield return RegistrationRequest;
        yield return IsAccepted;
    }
}
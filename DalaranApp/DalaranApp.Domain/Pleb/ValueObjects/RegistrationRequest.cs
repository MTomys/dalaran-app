using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Pleb.ValueObjects;

public class RegistrationRequest : ValueObject
{
    public DateTime OccuredAt { get; }
    public string RequestedUsername { get; }
    public string RequestedPassword { get; }

    public RegistrationRequest(DateTime occuredAt, string requestedUsername, string requestedPassword)
    {
        OccuredAt = occuredAt;
        RequestedUsername = requestedUsername;
        RequestedPassword = requestedPassword;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return OccuredAt;
        yield return RequestedUsername;
        yield return RequestedPassword;
    }
}
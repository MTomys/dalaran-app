using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Plebs.ValueObjects;

public class RegistrationRequest : ValueObject
{
    public DateTime OccuredAt { get; }
    public string RequestedUsername { get; }
    public string RequestedPassword { get; }
    public string RequestMessage { get; }

    public RegistrationRequest(DateTime occuredAt, string requestedUsername, string requestedPassword,
        string requestMessage)
    {
        OccuredAt = occuredAt;
        RequestedUsername = requestedUsername;
        RequestedPassword = requestedPassword;
        RequestMessage = requestMessage;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return OccuredAt;
        yield return RequestedUsername;
        yield return RequestedPassword;
        yield return RequestMessage;
    }
}
namespace DalaranApp.Contracts.Admins.PlebRequests;

public record GetPlebRequestResponse(
    string PlebId,
    bool IsAccepted,
    RegistrationRequest RegistrationRequest
);

public record RegistrationRequest(
    DateTime OccuredAt,
    string RequestedUsername,
    string RequestedPassword,
    string RequestMessage
);
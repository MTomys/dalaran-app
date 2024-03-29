﻿using DalaranApp.Domain.Common.Models;
using DalaranApp.Domain.Plebs.ValueObjects;

namespace DalaranApp.Domain.Admins.ValueObjects;

public class PlebRegistrationRequest : ValueObject
{
    public Guid PlebId { get; }
    public RegistrationRequest RegistrationRequest { get; }

    public PlebRegistrationRequest(
        Guid plebId, RegistrationRequest registrationRequest, bool isAccepted)
    {
        PlebId = plebId;
        RegistrationRequest = registrationRequest;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return PlebId;
        yield return RegistrationRequest;
    }
}
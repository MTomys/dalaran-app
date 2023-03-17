using DalaranApp.Domain.Common.Models;
using DalaranApp.Domain.Pleb.ValueObjects;

namespace DalaranApp.Domain.Pleb;

public sealed class Pleb : AggregateRoot<Guid>
{
    public RegistrationRequest RegistrationRequest { get; }

    private Pleb()
    {
    }

    private Pleb(Guid id, RegistrationRequest registrationRequest) : base(id)
    {
        RegistrationRequest = registrationRequest;
    }

    public static Pleb Create(RegistrationRequest registrationRequest)
    {
        return new Pleb(
            Guid.NewGuid(),
            registrationRequest
        );
    }
}
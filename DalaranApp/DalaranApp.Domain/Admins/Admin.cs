using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Admins;

public class Admin : AggregateRoot<Guid>
{
    private readonly List<PlebRegistrationRequest> _plebRegistrationRequests;
    public string Username { get; set; }
    public string Password { get; set; }

    public Admin()
    {
        _plebRegistrationRequests = new List<PlebRegistrationRequest>();
    }

    public void AddPlebRequest(PlebRegistrationRequest plebRegistrationRequest)
    {
        _plebRegistrationRequests.Add(plebRegistrationRequest);
    }

    public List<PlebRegistrationRequest> PlebRegistrationRequests =>
        new(_plebRegistrationRequests);
}
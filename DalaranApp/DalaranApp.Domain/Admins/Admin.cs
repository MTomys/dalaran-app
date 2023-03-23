using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Admins;

public class Admin : AggregateRoot<Guid>
{
    private readonly List<PlebRegistrationRequest> _plebRegistrationRequests;
    public string ProfileName { get; }

    private Admin(string profileName, Guid id) : base(id)
    {
        ProfileName = profileName;
        _plebRegistrationRequests = new List<PlebRegistrationRequest>();
    }

    public void AddPlebRequest(PlebRegistrationRequest plebRegistrationRequest)
    {
        _plebRegistrationRequests.Add(plebRegistrationRequest);
    }

    public static Admin Create(string username)
    {
        return new Admin(username, Guid.NewGuid());
    }

    public static Admin Create(string username, Guid id)
    {
        return new Admin(username, id);
    }

    public List<PlebRegistrationRequest> PlebRegistrationRequests =>
        new(_plebRegistrationRequests);
}
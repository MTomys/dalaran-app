using DalaranApp.Domain.Bajs.ValueObjects;
using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Bajs;

public class Baj : AggregateRoot<Guid>
{
    private readonly IList<Message> _messages;
    private readonly IList<BajContact> _bajContacts;
    public string ProfileName { get; }

    private Baj(string profileName, Guid id) : base(id)
    {
        ProfileName = profileName;
        Id = id;
        _messages = new List<Message>();
        _bajContacts = new List<BajContact>();
    }

    public static Baj Create(string profileName)
    {
        return new Baj(profileName, Guid.NewGuid());
    }

    public static Baj Create(string profileName, Guid id)
    {
        return new Baj(profileName, id);
    }
}
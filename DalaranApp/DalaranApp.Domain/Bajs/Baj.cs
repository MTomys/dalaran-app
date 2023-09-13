using DalaranApp.Domain.Bajs.ValueObjects;
using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Bajs;

public class Baj : AggregateRoot<Guid>
{
    private readonly IList<Message> _messages;
    private readonly IList<BajContact> _bajContacts;
    public string ProfileName { get; }
    public string ProfilePicture { get; }

    private Baj()
    {
    }

    private Baj(string profileName, string profilePicture, Guid id) : base(id)
    {
        ProfileName = profileName;
        ProfilePicture = profilePicture;
        Id = id;
        _messages = new List<Message>();
        _bajContacts = new List<BajContact>();
    }

    public static Baj Create(string profileName)
    {
        return new Baj(profileName, string.Empty, new Guid());
    }

    public static Baj Create(string profileName, Guid id)
    {
        return new Baj(profileName, string.Empty, id);
    }

    public static Baj Create(string profileName, string profilePicture, Guid id)
    {
        return new Baj(profileName, profilePicture, id);
    }

    public IReadOnlyList<Message> BajMessages =>
        new List<Message>(_messages).AsReadOnly();

    public IReadOnlyList<BajContact> BajContacts =>
        new List<BajContact>(_bajContacts).AsReadOnly();

    public void AddMessage(Message message)
    {
        _messages.Add(message);
    }

    public void AddContact(BajContact bajContact)
    {
        _bajContacts.Add(bajContact);
    }
}
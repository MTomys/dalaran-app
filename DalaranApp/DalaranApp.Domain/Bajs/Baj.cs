using DalaranApp.Domain.Bajs.ValueObjects;
using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Bajs;

public class Baj : AggregateRoot<Guid>
{
    private readonly IList<Message> _messages;
    private readonly IList<BajContact> _bajContacts;
    public string ProfileName { get; }
    public byte[] ProfilePicture { get; }

    private Baj()
    {
    }

    private Baj(string profileName, Guid id) : base(id)
    {
        ProfileName = profileName;
        ProfilePicture = Array.Empty<byte>();
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
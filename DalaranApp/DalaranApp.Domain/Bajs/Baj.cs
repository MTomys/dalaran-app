using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Bajs;

public class Baj : AggregateRoot<Guid>
{
    public string ProfileName { get; }

    private Baj(string profileName, Guid id) : base(id)
    {
        ProfileName = profileName;
        Id = id;
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
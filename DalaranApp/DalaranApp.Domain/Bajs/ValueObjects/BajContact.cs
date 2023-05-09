using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Bajs.ValueObjects;

public class BajContact : ValueObject
{
    public Guid BajId { get; }
    public string BajProfileName { get; }
    public DateTime AddedAsContactAt { get; }

    public BajContact(Guid bajId, string bajProfileName, DateTime addedAsContactAt)
    {
        BajId = bajId;
        BajProfileName = bajProfileName;
        AddedAsContactAt = addedAsContactAt;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return BajId;
        yield return BajProfileName;
        yield return AddedAsContactAt;
    }
}
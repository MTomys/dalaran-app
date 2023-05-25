using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Bajs.ValueObjects;

public class BajContact : ValueObject
{
    public Guid BajId { get; }
    public DateTime AddedAsContactAt { get; }

    public BajContact(Guid bajId, DateTime addedAsContactAt)
    {
        BajId = bajId;
        AddedAsContactAt = addedAsContactAt;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return BajId;
        yield return AddedAsContactAt;
    }
}
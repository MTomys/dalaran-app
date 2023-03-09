using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Auth.ValueObjects;

public class SecretPassphrase : ValueObject
{
    public IReadOnlyList<string> Passphrase => new List<string>
    {
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
    };

    public SecretPassphrase()
    {
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Passphrase;
    }

    public bool Equals(ValueObject? other)
    {
        return Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var valueObject = (SecretPassphrase)obj;
        return Passphrase.SequenceEqual(valueObject.Passphrase);
    }

}
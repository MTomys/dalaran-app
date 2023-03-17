using DalaranApp.Domain.Pleb.ValueObjects;

namespace DalaranApp.Tests.Domain.Pleb.ValueObjects;

public class RegistrationRequestTests
{
    private static readonly DateTime CurrentDateTime = DateTime.Now;

    [Theory]
    [MemberData(nameof(RegistrationRequestData))]
    public void Compare_BasedOnProperties_ReturnsAppropriateResult(
        DateTime dateTime,
        (string, string) reg1,
        (string, string) reg2,
        bool expected)
    {
        var registration1 = new RegistrationRequest(dateTime, reg1.Item1, reg1.Item2);
        var registration2 = new RegistrationRequest(dateTime, reg2.Item1, reg2.Item2);

        var result = registration1.Equals(registration2);

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(RegistrationRequestData))]
    public void EqualsOperator_BasedOnProperties_ReturnsAppropriateResult(
        DateTime dateTime,
        (string, string) reg1,
        (string, string) reg2,
        bool expected)
    {
        var registration1 = new RegistrationRequest(dateTime, reg1.Item1, reg1.Item2);
        var registration2 = new RegistrationRequest(dateTime, reg2.Item1, reg2.Item2);

        var result = (registration1 == registration2);

        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> RegistrationRequestData()
    {
        yield return new object[] { CurrentDateTime, ("username1", "password1"), ("username1", "password1"), true };
        yield return new object[] { CurrentDateTime, ("username1", "password1"), ("username2", "password2"), false };
        yield return new object[] { CurrentDateTime, ("username1", "password1"), ("username1", "password2"), false };
        yield return new object[] { CurrentDateTime, ("username1", "password1"), ("username2", "password1"), false };
    }
}
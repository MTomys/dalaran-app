namespace DalaranApp.Tests.UnitTests.Application.TestUtils.Common;

public static class CommonTestHelpers
{
    public static Guid GetGuidIdFromIndex(string baseGuid, int index)
    {
        var formattedIndex = index.ToString().PadLeft(12, '0');
        return Guid.Parse($"{baseGuid}{formattedIndex}");
    }
}
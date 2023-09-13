using DalaranApp.Tests.UnitTests.Application.TestUtils.Common;

namespace DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;

public static partial class TestConstants
{
    public static class Bajs
    {
        private const string BaseBajId = "30000000-0000-0000-0000-";
        public static readonly Guid BajId = BajIdFromIndex(0);
        public const string BajProfileName = "Baj Profile Name";
        public const string BajProfilePicture = "Baj Profile Picture";
        public const string MessageContent = "Test message content";

        public const string NewcomerBajProfileName = "Newcomer Baj Profile Name";

        public static Guid BajIdFromIndex(int index)
            => CommonTestHelpers.GetGuidIdFromIndex(BaseBajId, index);

        public static string BajProfileNameFromId(int index)
            => $"{BajProfileName}_{index}";

        public static string BajProfilePictureFromId(int index)
            => $"{BajProfilePicture}_{index}";
    }
}
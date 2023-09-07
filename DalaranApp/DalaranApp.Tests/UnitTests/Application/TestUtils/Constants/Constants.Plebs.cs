using DalaranApp.Tests.UnitTests.Application.TestUtils.Common;

namespace DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;

public static partial class Constants
{
    public static class Plebs
    {
        private const string BasePlebId = "10000000-0000-0000-0000-";
        public const string ProfileName = "Pleb Profile Name";
        public static readonly Guid PlebId = PlebIdFromIndex(0);

        public const string RequestedUsername = "Requested_Username";
        public const string RequestedPassword = "Requested_Password";
        public const string RequestMessage = "Request Message";
        
        public static Guid PlebIdFromIndex(int index)
            => CommonTestHelpers.GetGuidIdFromIndex(BasePlebId, index);
    }
}
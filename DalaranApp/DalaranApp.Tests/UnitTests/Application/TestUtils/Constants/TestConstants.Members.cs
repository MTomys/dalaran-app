using DalaranApp.Tests.UnitTests.Application.TestUtils.Common;

namespace DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;

public static partial class TestConstants
{
    public static class Members
    {
        private const string BaseMemberId = "20000000-0000-0000-0000-";
        public static readonly Guid MemberId = MemberIdFromIndex(0);

        public static Guid MemberIdFromIndex(int index)
            => CommonTestHelpers.GetGuidIdFromIndex(BaseMemberId, index);
    }
}
using DalaranApp.Domain.Admins;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Common;

namespace DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;

public static partial class Constants
{
    public static class Admins
    {
        private const string BaseAdminId = "00000000-0000-0000-0000-";
        public const string ProfileName = "Admin Profile Name";
        public static readonly Guid AdminId = AdminIdFromIndex(0);

        public static Guid AdminIdFromIndex(int index)
        {
            return CommonTestHelpers.GetGuidIdFromIndex(BaseAdminId, index);
        }
    }
}
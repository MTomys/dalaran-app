using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;

namespace DalaranApp.Tests.UnitTests.Application.Auth.TestUtils;

public static class AuthHandlersTestUtils
{
    public static Member CreateBajMember()
        => Member.Create(
            TestConstants.Members.MemberId,
            TestConstants.Auth.Username,
            TestConstants.Auth.Password,
            Roles.Baj
        );
}
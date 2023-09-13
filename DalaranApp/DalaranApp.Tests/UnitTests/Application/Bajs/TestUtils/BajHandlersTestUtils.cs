using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Domain.Bajs;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;

namespace DalaranApp.Tests.UnitTests.Application.Bajs.TestUtils;

public static class BajHandlersTestUtils
{
    public static Baj CreateBaj()
        => Baj.Create(
            TestConstants.Bajs.BajProfileName,
            TestConstants.Bajs.BajProfilePicture,
            TestConstants.Bajs.BajId);

    public static Member CreateNewcomerBajMember()
        => Member.Create(
            TestConstants.Members.MemberId,
            TestConstants.Auth.Username,
            TestConstants.Auth.Password,
            Roles.NewcomerBaj
        );
}
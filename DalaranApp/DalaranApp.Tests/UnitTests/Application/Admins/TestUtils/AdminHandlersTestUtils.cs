using DalaranApp.Domain.Admins;
using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.Plebs;
using DalaranApp.Domain.Plebs.ValueObjects;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace DalaranApp.Tests.UnitTests.Application.Admins.TestUtils;

public static class AdminHandlersTestUtils
{
    public static IEnumerable<Decision> CreatePositiveDecisions(int count)
        => Enumerable.Range(0, count)
            .Select(i => new Decision(
                TestConstants.Admins.AdminIdFromIndex(i),
                TestConstants.Plebs.PlebIdFromIndex(i),
                DateTime.Now,
                true
            ));

    public static IEnumerable<Decision> CreateNegativeDecisions(int count)
        => Enumerable.Range(0, count)
            .Select(i => new Decision(
                TestConstants.Admins.AdminIdFromIndex(i),
                TestConstants.Plebs.PlebIdFromIndex(i),
                DateTime.Now,
                false
            ));

    public static Admin CreateAdmin()
        => Admin.Create(TestConstants.Admins.ProfileName, TestConstants.Admins.AdminId);

    public static Pleb CreatePleb()
        => Pleb.Create(
            TestConstants.Plebs.PlebId,
            CreateRegistrationRequest()
        );

    public static RegistrationRequest CreateRegistrationRequest()
        => new(
            DateTime.Now,
            TestConstants.Plebs.RequestedUsername,
            TestConstants.Plebs.RequestedPassword,
            TestConstants.Plebs.RequestMessage
        );

    public static PlebRegistrationRequest CreateAcceptedPlebRegistrationRequest()
        => new (
            TestConstants.Plebs.PlebId,
            CreateRegistrationRequest(),
            isAccepted: true
        );
}
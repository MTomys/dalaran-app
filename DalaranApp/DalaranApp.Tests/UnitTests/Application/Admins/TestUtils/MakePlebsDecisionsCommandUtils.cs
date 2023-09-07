using DalaranApp.Domain.Admins;
using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.Plebs;
using DalaranApp.Domain.Plebs.ValueObjects;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;

namespace DalaranApp.Tests.UnitTests.Application.Admins.TestUtils;

public static class MakePlebsDecisionsCommandUtils
{
    public static IEnumerable<Decision> CreatePositiveDecisions(int count)
        => Enumerable.Range(0, count)
            .Select(i => new Decision(
                Constants.Admins.AdminIdFromIndex(i),
                Constants.Plebs.PlebIdFromIndex(i),
                DateTime.Now,
                true
            ));

    public static IEnumerable<Decision> CreateNegativeDecisions(int count)
        => Enumerable.Range(0, count)
            .Select(i => new Decision(
                Constants.Admins.AdminIdFromIndex(i),
                Constants.Plebs.PlebIdFromIndex(i),
                DateTime.Now,
                false
            ));

    public static Admin CreateAdmin()
        => Admin.Create(Constants.Admins.ProfileName, Constants.Admins.AdminId);

    public static Pleb CreatePleb()
        => Pleb.Create(
            Constants.Plebs.PlebId,
            CreateRegistrationRequest()
        );

    public static RegistrationRequest CreateRegistrationRequest()
        => new RegistrationRequest(
            DateTime.Now,
            Constants.Plebs.RequestedUsername,
            Constants.Plebs.RequestedPassword,
            Constants.Plebs.RequestMessage
        );
}
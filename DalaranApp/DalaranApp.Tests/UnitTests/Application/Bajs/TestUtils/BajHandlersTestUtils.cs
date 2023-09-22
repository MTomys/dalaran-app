using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Domain.Bajs;
using DalaranApp.Domain.Bajs.ValueObjects;
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

    public static IEnumerable<Baj> CreateBajs(int amount, int offset = 0)
        => Enumerable.Range(offset, amount)
            .Select(i => Baj.Create(
                TestConstants.Bajs.BajProfileNameFromId(i),
                TestConstants.Bajs.BajIdFromIndex(i)
            ));

    public static Baj CreateBajWithContacts(int numberOfContacts, int offset = 0)
    {
        var baj = CreateBaj();
        var bajContacts = Enumerable.Range(offset, numberOfContacts)
            .Select(i => new BajContact(TestConstants.Bajs.BajIdFromIndex(i), DateTime.Now));
        foreach (var contact in bajContacts)
        {
            baj.AddContact(contact);
        }
        return baj;
    }
}
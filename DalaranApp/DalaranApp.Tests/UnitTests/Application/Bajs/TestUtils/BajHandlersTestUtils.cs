using DalaranApp.Application.Bajs.Common;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Domain.Bajs;
using DalaranApp.Domain.Bajs.ValueObjects;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;
using BajContact = DalaranApp.Domain.Bajs.ValueObjects.BajContact;

namespace DalaranApp.Tests.UnitTests.Application.Bajs.TestUtils;

public static class BajHandlersTestUtils
{
    public static Baj CreateBaj()
        => Baj.Create(
            TestConstants.Bajs.BajProfileName,
            TestConstants.Bajs.BajProfilePicture,
            TestConstants.Bajs.BajId);

    public static Baj CreateBajFromIndex(int i)
        => Baj.Create(
            TestConstants.Bajs.BajProfileNameFromId(i),
            TestConstants.Bajs.BajProfilePictureFromId(i),
            TestConstants.Bajs.BajIdFromIndex(i)
        );

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

    public static Baj CreateBajWithSentAndReceivedMessages(int numberOfMessages)
    {
        var senderBaj = CreateBajFromIndex(0);
        var receiverBaj = CreateBajFromIndex(1);

        var sentMessages =
            CreateRangeOfMessages(numberOfMessages, senderBaj: senderBaj, receiverBaj: receiverBaj);
        var receivedMessages =
            CreateRangeOfMessages(numberOfMessages, senderBaj: receiverBaj, receiverBaj: senderBaj);
        foreach (var sentMessage in sentMessages)
        {
            senderBaj.AddMessage(sentMessage);
        }

        foreach (var receivedMessage in receivedMessages)
        {
            senderBaj.AddMessage(receivedMessage);
        }

        return senderBaj;
    }

    private static IEnumerable<Message> CreateRangeOfMessages(int numberOfMessages, Baj senderBaj, Baj receiverBaj)
    {
        return Enumerable.Range(0, numberOfMessages)
            .Select(i => new Message(
                senderBaj.Id, receiverBaj.Id, TestConstants.Bajs.MessageContent,
                DateTime.Now.AddHours(-i)));
    }
}
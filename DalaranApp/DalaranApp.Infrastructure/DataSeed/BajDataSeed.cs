﻿using DalaranApp.Domain.Bajs;
using DalaranApp.Domain.Bajs.ValueObjects;

namespace DalaranApp.Infrastructure.DataSeed;

public class BajDataSeed
{
    public static List<Baj> GenerateBajs()
    {
        var bajs = new List<Baj>
        {
            Baj.Create("biggdawg1",     Guid.Parse("00000000-0000-0000-0000-200000000001")),
            Baj.Create("funkyfish3",    Guid.Parse("00000000-0000-0000-0000-200000000002")),
            Baj.Create("jazzyjaguar5",  Guid.Parse("00000000-0000-0000-0000-200000000003"))
        };
        AddBajContactsToBajs(bajs);
        AddMessagesToBajs(bajs);
        return bajs;
    }

    private static void AddBajContactsToBajs(List<Baj> bajs)
    {
        var random = new Random();
        foreach (var baj in bajs)
        {
            var otherBajs = bajs.Except(new List<Baj> { baj });

            foreach (var otherBaj in otherBajs)
            {
                baj.AddContact(new BajContact(otherBaj.Id, DateTime.Now.AddDays(-random.Next(1, 100))));
            }
        }
    }

    private static void AddMessagesToBajs(List<Baj> bajs)
    {
        var messagesContent = GetMessagesContent();
        var longMessage =
            "This is a longer message that we are using for the example. It is designed to show how a longer message might be used in the code. This message is generated by an AI, and is designed to fill space in this example, containing 50 words.";

        var random = new Random();
        for (var i = 0; i < 10; i++)
        {
            foreach (var senderBaj in bajs)
            {
                var otherBajs = bajs.Except(new List<Baj> { senderBaj }).ToList();
                var receiver = otherBajs[random.Next(otherBajs.Count)];
                var content = (i % 5 == 0) ? longMessage : messagesContent[random.Next(messagesContent.Count)];
                var sentAt = DateTime.Now.AddDays(-random.Next(1, 100));

                senderBaj.AddMessage(new Message(senderBaj.Id, receiver.Id, content, sentAt));
            }
        }
    }

    private static List<string> GetMessagesContent()
    {
        List<string> messagesContent = new List<string>()
        {
            "Hello",
            "What's up",
            "Hey, how are you doing?",
            "Long time no see",
            "It was good seeing you today.",
            "Hope you're doing well.",
            "Can't wait to catch up.",
            "Hey, do you remember when...",
            "Been a while, how's everything going?",
            "Did you get a chance to check out that movie?"
        };
        return messagesContent;
    }
}
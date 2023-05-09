using DalaranApp.Domain.Common.Models;

namespace DalaranApp.Domain.Bajs.ValueObjects;

public class Message : ValueObject
{
    public Guid SenderId { get; }
    public Guid ReceiverId { get; }
    public string Content { get; }
    public DateTime SentAt { get; }

    public Message(Guid senderId, Guid receiverId, string content, DateTime sentAt)
    {
        SenderId = senderId;
        ReceiverId = receiverId;
        Content = content;
        SentAt = sentAt;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return SenderId;
        yield return ReceiverId;
        yield return Content;
        yield return SentAt;
    }
}
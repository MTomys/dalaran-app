using DalaranApp.Application.Bajs.Common;
using DalaranApp.Application.Bajs.Queries;
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Tests.UnitTests.Application.Bajs.TestUtils;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;
using Moq;

namespace DalaranApp.Tests.UnitTests.Application.Bajs.Queries;

public class GetBajMessagesQueryHandlerTests
{
    private readonly Mock<IBajRepository> _bajRepository;
    private readonly GetBajMessagesQueryHandler _handler;

    public GetBajMessagesQueryHandlerTests()
    {
        _bajRepository = new Mock<IBajRepository>();
        _handler = new GetBajMessagesQueryHandler(
            _bajRepository.Object
        );
    }

    [Fact]
    public async Task HandleGetBajMessages_ShouldReturnEmptyCollection_WhenBajHasNoMessages()
    {
        var bajWithNoMessages = BajHandlersTestUtils.CreateBajFromIndex(0);
        var bajContact = BajHandlersTestUtils.CreateBajFromIndex(1);

        var getBajMessagesQuery =
            new GetBajMessagesQuery(TestConstants.Bajs.BajId, bajContact.Id);

        _bajRepository.Setup(br => br.GetById(bajWithNoMessages.Id))
            .Returns(bajWithNoMessages);
        _bajRepository.Setup(br => br.GetById(bajContact.Id))
            .Returns(bajContact);

        var result = await _handler.Handle(getBajMessagesQuery, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task HandleGetBajMessages_ShouldReturnSentAndReceivedMessages_WhenBajHasSentAndReceivedMessages()
    {
        var bajWithMessages = BajHandlersTestUtils.CreateBajWithSentAndReceivedMessages(5);
        var bajContact = BajHandlersTestUtils.CreateBajFromIndex(1);
        var getBajMessagesQuery =
            new GetBajMessagesQuery(TestConstants.Bajs.BajId, bajContact.Id);

        _bajRepository.Setup(br => br.GetById(bajWithMessages.Id))
            .Returns(bajWithMessages);
        _bajRepository.Setup(br => br.GetById(bajContact.Id))
            .Returns(bajContact);

        var result = (await _handler.Handle(getBajMessagesQuery, CancellationToken.None))
            .ToList();

        Assert.Equal(bajWithMessages.BajMessages.Count, result.Count);
        Assert.True(ReceivedMessagesEqualAmountOfSentMessages(result, bajWithMessages.ProfileName));
    }

    private bool ReceivedMessagesEqualAmountOfSentMessages(
        List<BajMessage> bajMessages,
        string bajWithMessagesProfileName)
    {
        var receivedMessages = bajMessages.Where(bm => bm.Receiver == bajWithMessagesProfileName);
        var sentMessages = bajMessages.Where(bm => bm.Sender == bajWithMessagesProfileName);
        return receivedMessages.Count() == sentMessages.Count();
    }
}
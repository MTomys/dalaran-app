using System.Diagnostics;
using DalaranApp.Application.Bajs.Commands;
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Tests.UnitTests.Application.Bajs.TestUtils;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;
using Moq;

namespace DalaranApp.Tests.UnitTests.Application.Bajs.Commands;

public class AddMessageFromBajCommandHandlerTests
{
    private readonly Mock<IBajRepository> _bajRepositoryMock;
    private readonly AddMessageFromBajCommandHandler _handler;

    public AddMessageFromBajCommandHandlerTests()
    {
        _bajRepositoryMock = new Mock<IBajRepository>();
        _handler = new AddMessageFromBajCommandHandler(_bajRepositoryMock.Object);
    }

    [Fact]
    public async Task HandleAddMessageFromBaj_WhenValidMessageFound_ShouldUpdateBajMessages()
    {
        var returnedBaj = BajHandlersTestUtils.CreateBaj();
        var messageFromBajCommand = new AddMessageFromBajCommand(
            returnedBaj.Id,
            TestConstants.Bajs.BajIdFromIndex(1),
            returnedBaj.Id,
            TestConstants.Bajs.MessageContent,
            DateTime.Now
        );

        _bajRepositoryMock.Setup(br => br.GetById(returnedBaj.Id))
            .Returns(returnedBaj);

        await _handler.Handle(messageFromBajCommand, CancellationToken.None);

        _bajRepositoryMock.Verify(r => r.Update(returnedBaj),
            Times.Once);
        Assert.Single(returnedBaj.BajMessages);
    }
}
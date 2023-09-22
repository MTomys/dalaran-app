using DalaranApp.Application.Bajs.Queries;
using DalaranApp.Application.Common.Interfaces.Bajs;
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

}
using DalaranApp.Application.Bajs.Common;
using DalaranApp.Application.Bajs.Queries;
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Domain.Bajs;
using DalaranApp.Tests.UnitTests.Application.Bajs.TestUtils;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;
using Moq;

namespace DalaranApp.Tests.UnitTests.Application.Bajs.Queries;

public class GetBajMeQueryHandlerTests
{
    private readonly Mock<IBajRepository> _bajRepository;
    private readonly GetBajMeQueryHandler _handler;

    public GetBajMeQueryHandlerTests()
    {
        _bajRepository = new Mock<IBajRepository>();
        _handler = new GetBajMeQueryHandler(
            _bajRepository.Object
        );
    }

    [Fact]
    public async Task HandleGetBajMe_WhenBajFound_ShouldReturnMatchingBajMeInfo()
    {
        var getBajMeQuery = new GetBajMeQuery(TestConstants.Bajs.BajId);

        var returnedBaj = BajHandlersTestUtils.CreateBaj();
        _bajRepository.Setup(r => r.GetById(returnedBaj.Id))
            .Returns(returnedBaj);

        var response = await _handler.Handle(getBajMeQuery, CancellationToken.None);

        Assert.True(BajMeHasIdenticalFieldsToBaj(response, returnedBaj),
            "Expected returned bajMe to be identical to Baj from repository");
    }

    private bool BajMeHasIdenticalFieldsToBaj(BajMe bajMe, Baj baj)
    {
        return bajMe.ProfileName == baj.ProfileName
               && bajMe.ProfilePicture == baj.ProfilePicture
               && bajMe.Id == baj.Id;
    }
}
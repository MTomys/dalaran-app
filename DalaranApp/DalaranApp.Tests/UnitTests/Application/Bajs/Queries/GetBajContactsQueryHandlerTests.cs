using DalaranApp.Application.Bajs.Queries;
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Domain.Bajs.ValueObjects;
using DalaranApp.Tests.UnitTests.Application.Bajs.TestUtils;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;
using Moq;

namespace DalaranApp.Tests.UnitTests.Application.Bajs.Queries;

public class GetBajContactsQueryHandlerTests
{
    private readonly Mock<IBajRepository> _bajRepository;
    private readonly GetBajContactsQueryHandler _handler;

    public GetBajContactsQueryHandlerTests()
    {
        _bajRepository = new Mock<IBajRepository>();
        _handler = new GetBajContactsQueryHandler(_bajRepository.Object);
    }


    [Fact]
    public async Task HandleGetBajContacts_WhenBajHasNoContacts_ShouldReturnEmptyCollection()
    {
        var getBajContactsQuery = new GetBajContactsQuery(TestConstants.Bajs.BajId);

        var returnedBaj = BajHandlersTestUtils.CreateBaj();
        _bajRepository.Setup(br => br.GetById(returnedBaj.Id))
            .Returns(returnedBaj);

        var response = await _handler.Handle(getBajContactsQuery, CancellationToken.None);

        Assert.Empty(response);
    }

    [Fact]
    public async Task HandleGetBajContacts_WhenBajHasContacts_ShouldReturnCorrespondingBajContacts()
    {
        var getBajContactsQuery = new GetBajContactsQuery(TestConstants.Bajs.BajId);

        var returnedBaj = BajHandlersTestUtils.CreateBajWithContacts(5);
        var returnedBajContactsBajs = BajHandlersTestUtils.CreateBajs(5, 1)
            .ToList();

        _bajRepository.Setup(br => br.GetById(returnedBaj.Id))
            .Returns(returnedBaj);
        _bajRepository.Setup(br => br.GetManyById(It.Is<IEnumerable<Guid>>(
                ids => IsValidContactIdsCall(ids, returnedBaj.BajContacts))))
            .Returns(returnedBajContactsBajs);

        var response = await _handler.Handle(getBajContactsQuery, CancellationToken.None);

        Assert.All(response,
            responseItem => Assert.Contains(
                returnedBajContactsBajs.Select(b => b.Id.ToString()), bId => bId == responseItem.ContactId)
        );
    }

    private bool IsValidContactIdsCall(
        IEnumerable<Guid> contactIds,
        IEnumerable<BajContact> bajContacts)
    {
        return contactIds.All(cId => bajContacts.Any(bc => bc.BajId == cId));
    }
}
using DalaranApp.Application.Admins.Queries;
using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Tests.UnitTests.Application.Admins.TestUtils;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;
using Moq;

namespace DalaranApp.Tests.UnitTests.Application.Admins.Queries;

public class GetPlebRequestsQueryHandlerTests
{
    private readonly Mock<IAdminRepository> _adminRepositoryMock;
    private readonly GetPlebRequestsQueryHandler _handler;

    public GetPlebRequestsQueryHandlerTests()
    {
        _adminRepositoryMock = new Mock<IAdminRepository>();
        _handler = new GetPlebRequestsQueryHandler(
            _adminRepositoryMock.Object);
    }

    [Fact]
    public async Task HandleGetPlebRequests_WhenAdminHasPlebRegistrationRequests_ShouldReturnRequests()
    {
        var returnedAdmin = AdminHandlersTestUtils.CreateAdmin();
        var acceptedPlebRegistrationRequest = AdminHandlersTestUtils.CreateAcceptedPlebRegistrationRequest();
        returnedAdmin.AddPlebRequest(acceptedPlebRegistrationRequest);

        _adminRepositoryMock.Setup(r => r.GetById(returnedAdmin.Id))
            .Returns(returnedAdmin);

        var getPlebRequestsQuery = new GetPlebsQuery(TestConstants.Admins.AdminId);
        var response = await _handler.Handle(getPlebRequestsQuery, CancellationToken.None);

        Assert.Contains(acceptedPlebRegistrationRequest, response);
    }

    [Fact]
    public async Task HandleGetPlebRequests_WhenAdminDoesNotHavePlebRegistrationRequests_ShouldReturnEmptyCollection()
    {
        var returnedAdmin = AdminHandlersTestUtils.CreateAdmin();
        var acceptedPlebRegistrationRequest = AdminHandlersTestUtils.CreateAcceptedPlebRegistrationRequest();

        _adminRepositoryMock.Setup(r => r.GetById(returnedAdmin.Id))
            .Returns(returnedAdmin);

        var getPlebRequestsQuery = new GetPlebsQuery(TestConstants.Admins.AdminId);
        var response = await _handler.Handle(getPlebRequestsQuery, CancellationToken.None);

        Assert.Empty(response);
    }
}
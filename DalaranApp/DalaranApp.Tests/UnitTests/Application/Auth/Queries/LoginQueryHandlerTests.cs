using DalaranApp.Application.Auth.Common;
using DalaranApp.Application.Auth.Queries;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth;
using DalaranApp.Tests.UnitTests.Application.Auth.TestUtils;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;
using Moq;

namespace DalaranApp.Tests.UnitTests.Application.Auth.Queries;

public class LoginQueryHandlerTests
{
    private readonly Mock<IMemberRepository> _memberRepositoryMock;
    private readonly Mock<IJwtTokenProvider> _jwtTokenProviderMock;
    private readonly LoginQueryHandler _handler;

    public LoginQueryHandlerTests()
    {
        _memberRepositoryMock = new Mock<IMemberRepository>();
        _jwtTokenProviderMock = new Mock<IJwtTokenProvider>();
        _handler = new LoginQueryHandler(
            _memberRepositoryMock.Object,
            _jwtTokenProviderMock.Object
        );
    }

    [Fact]
    public async Task HandleLoginQuery_ShouldReturnNull_WhenMemberWithGivenCredentialsNotFound()
    {
        var loginQuery = new LoginQuery(TestConstants.Auth.Username, TestConstants.Auth.Password);

        _memberRepositoryMock.Setup(r => r.GetByUsernameAndPassword(
                It.IsAny<string>(),
                It.IsAny<string>()))
            .Returns(null as Member);

        var response = await _handler.Handle(loginQuery, CancellationToken.None);

        Assert.Null(response);
    }

    [Fact]
    public async Task HandleLoginQuery_ShouldReturnMemberWithToken_WhenMemberWithGivenCredentialsFound()
    {
        var loginQuery = new LoginQuery(TestConstants.Auth.Username, TestConstants.Auth.Password);

        var returnedMember = AuthHandlersTestUtils.CreateBajMember();

        _memberRepositoryMock.Setup(r => r.GetByUsernameAndPassword(
                TestConstants.Auth.Username,
                TestConstants.Auth.Password))
            .Returns(returnedMember);
        _jwtTokenProviderMock.Setup(p => p.Generate(returnedMember))
            .Returns(TestConstants.Auth.JwtToken);

        var response = await _handler.Handle(loginQuery, CancellationToken.None);

        Assert.True(ResponseMatchesMember(response!, returnedMember));
        Assert.Equal(TestConstants.Auth.JwtToken, response!.Token);
    }

    private bool ResponseMatchesMember(AuthenticationResponse authResponse, Member member)
        => authResponse.Username == member.Username
           && authResponse.Role == member.Role;
}
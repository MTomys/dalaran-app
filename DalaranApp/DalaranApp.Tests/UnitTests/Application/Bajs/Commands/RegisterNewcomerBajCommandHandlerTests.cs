using DalaranApp.Application.Auth.Constants;
using DalaranApp.Application.Bajs.Commands;
using DalaranApp.Application.Common.Exceptions.Bajs;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Domain.Bajs;
using DalaranApp.Tests.UnitTests.Application.Bajs.TestUtils;
using DalaranApp.Tests.UnitTests.Application.TestUtils.Constants;
using Moq;

namespace DalaranApp.Tests.UnitTests.Application.Bajs.Commands;

public class RegisterNewcomerBajCommandHandlerTests
{
    private readonly Mock<IBajRepository> _bajRepository;
    private readonly Mock<IMemberRepository> _memberRepository;
    private readonly Mock<IJwtTokenProvider> _tokenProvider;
    private readonly RegisterNewcomerBajCommandHandler _handler;

    public RegisterNewcomerBajCommandHandlerTests()
    {
        _bajRepository = new Mock<IBajRepository>();
        _memberRepository = new Mock<IMemberRepository>();
        _tokenProvider = new Mock<IJwtTokenProvider>();
        _handler = new RegisterNewcomerBajCommandHandler(
            _bajRepository.Object,
            _memberRepository.Object,
            _tokenProvider.Object
        );
    }

    [Fact]
    public async Task HandleRegisterBajCommand_WhenBajWithRequestedUsernameAlreadyExists_ShouldThrowBajTakenException()
    {
        var registerNewcomerBajCommand = new RegisterNewcomerBajCommand(
            TestConstants.Members.MemberId,
            TestConstants.Bajs.NewcomerBajProfileName
        );

        _bajRepository
            .Setup(r => r.ExistsWithProfileName(registerNewcomerBajCommand.NewcomerBajProfileName))
            .Returns(true);

        var action = () => _handler.Handle(registerNewcomerBajCommand, CancellationToken.None);

        await Assert.ThrowsAsync<BajUsernameAlreadyTakenException>(action);
    }

    [Fact]
    public async Task HandleRegisterBajCommand_WhenNewcomerBajIsValid_ShouldAddNewBajToRepository()
    {
        var registerNewcomerBajCommand = new RegisterNewcomerBajCommand(
            TestConstants.Members.MemberId,
            TestConstants.
                Bajs.NewcomerBajProfileName
        );
        var returnedNewcomerBaj = BajHandlersTestUtils.CreateNewcomerBajMember();

        _memberRepository.Setup(r => r.GetById(registerNewcomerBajCommand.MemberId))
            .Returns(returnedNewcomerBaj);

        await _handler.Handle(registerNewcomerBajCommand, CancellationToken.None);

        _bajRepository.Verify(r => r
                .Save(It.Is<Baj>(b =>
                    b.ProfileName == registerNewcomerBajCommand.NewcomerBajProfileName
                    && b.Id == returnedNewcomerBaj.Id)),
            Times.Once);
    }

    [Fact]
    public async Task HandleRegisterBajCommand_WhenNewcomerBajIsValid_ShouldUpdateBajAsNewMember()
    {
        var registerNewcomerBajCommand = new RegisterNewcomerBajCommand(
            TestConstants.Members.MemberId,
            TestConstants.Bajs.NewcomerBajProfileName
        );
        var newcomerBaj = BajHandlersTestUtils.CreateNewcomerBajMember();

        _memberRepository.Setup(r => r.GetById(registerNewcomerBajCommand.MemberId))
            .Returns(newcomerBaj);

        await _handler.Handle(registerNewcomerBajCommand, CancellationToken.None);

        _memberRepository.Verify(r => r.Update(newcomerBaj), Times.Once());
    }

    [Fact]
    public async Task HandleRegisterBajCommand_WhenNewcomerBajIsValid_ShouldReturnAuthResponse()
    {
        var registerNewcomerBajCommand = new RegisterNewcomerBajCommand(
            TestConstants.Members.MemberId,
            TestConstants.Bajs.NewcomerBajProfileName
        );

        var returnedNewcomerBaj = BajHandlersTestUtils.CreateNewcomerBajMember();

        _memberRepository.Setup(r => r.GetById(registerNewcomerBajCommand.MemberId))
            .Returns(returnedNewcomerBaj);
        _tokenProvider.Setup(tp => tp
                .Generate(It.Is<Member>(m => m.Id == returnedNewcomerBaj.Id)))
            .Returns(TestConstants.Auth.JwtToken);

        var response = await _handler.Handle(registerNewcomerBajCommand, CancellationToken.None);

        Assert.Equal(registerNewcomerBajCommand.NewcomerBajProfileName, response.Username);
        Assert.Equal(TestConstants.Auth.JwtToken, response.Token);
        Assert.Equal(Roles.Baj, response.Role);
    }
}
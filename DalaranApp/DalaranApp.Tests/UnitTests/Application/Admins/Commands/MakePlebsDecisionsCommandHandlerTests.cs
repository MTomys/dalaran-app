using System.Linq.Expressions;
using DalaranApp.Application.Admins.Commands;
using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Plebs;
using DalaranApp.Domain.Admins;
using DalaranApp.Domain.Admins.ValueObjects;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Plebs;
using DalaranApp.Tests.UnitTests.Application.Admins.TestUtils;
using Moq;

namespace DalaranApp.Tests.UnitTests.Application.Admins.Commands;

public class MakePlebsDecisionsCommandHandlerTests
{
    private readonly Mock<IMemberRepository> _memberRepositoryMock;
    private readonly Mock<IAdminRepository> _adminRepositoryMock;
    private readonly Mock<IPlebRepository> _plebRepositoryMock;
    private readonly MakePlebsDecisionsCommandHandler _handler;

    public MakePlebsDecisionsCommandHandlerTests()
    {
        _adminRepositoryMock = new Mock<IAdminRepository>();
        _memberRepositoryMock = new Mock<IMemberRepository>();
        _plebRepositoryMock = new Mock<IPlebRepository>();
        _handler = new MakePlebsDecisionsCommandHandler(
            _memberRepositoryMock.Object,
            _adminRepositoryMock.Object,
            _plebRepositoryMock.Object
        );
    }

    [Fact]
    public async Task HandleMakePlebsDecisions_WhenPositiveDecisionsFound_ShouldCreateNewMembers()
    {
        var makePlebsDecisionCommand = new MakePlebsDecisionsCommand(
            MakePlebsDecisionsCommandUtils.CreatePositiveDecisions(1));
        var returnedAdmin = MakePlebsDecisionsCommandUtils.CreateAdmin();
        var returnedPleb = MakePlebsDecisionsCommandUtils.CreatePleb();

        _adminRepositoryMock.Setup(r => r.GetById(returnedAdmin.Id))
            .Returns(returnedAdmin);
        _plebRepositoryMock.Setup(r => r.GetById(returnedPleb.Id))
            .Returns(returnedPleb);

        await _handler.Handle(makePlebsDecisionCommand, CancellationToken.None);

        _memberRepositoryMock.Verify(r => r.Add(
            It.Is(MemberMatchesPlebRequest(returnedPleb))
        ));
    }

    private static Expression<Func<Member, bool>> MemberMatchesPlebRequest(Pleb returnedPleb)
    {
        return m => m.Username == returnedPleb.RegistrationRequest.RequestedUsername;
    }

    [Fact]
    public async Task HandleMakePlebsDecisions_WhenPositiveDecisionsFound_ShouldAddNewDecisionsToCorrespondingAdmin()
    {
        var makePlebsDecisionCommand = new MakePlebsDecisionsCommand(
            MakePlebsDecisionsCommandUtils.CreatePositiveDecisions(1));

        await _handler.Handle(makePlebsDecisionCommand, CancellationToken.None);
    }

    [Fact]
    public async Task HandleMakePlebsDecisions_WhenNoPositiveDecisionsFound_ShouldNotCreateNewMembers()
    {
        var makePlebsDecisionCommand = new MakePlebsDecisionsCommand(
            MakePlebsDecisionsCommandUtils.CreateNegativeDecisions(1));

        await _handler.Handle(makePlebsDecisionCommand, CancellationToken.None);
    }
}
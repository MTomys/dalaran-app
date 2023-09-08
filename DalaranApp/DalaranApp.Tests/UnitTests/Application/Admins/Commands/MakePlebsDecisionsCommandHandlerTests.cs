using DalaranApp.Application.Admins.Commands;
using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Plebs;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;
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
        var returnedAdmin = AdminHandlersTestUtils.CreateAdmin();
        var returnedPleb = AdminHandlersTestUtils.CreatePleb();
        var positiveDecisions = AdminHandlersTestUtils.CreatePositiveDecisions(1)
            .ToList();
        var makePlebsDecisionCommand = new MakePlebsDecisionsCommand(positiveDecisions);

        _adminRepositoryMock.Setup(r => r.GetById(returnedAdmin.Id))
            .Returns(returnedAdmin);
        _plebRepositoryMock.Setup(r => r.GetById(returnedPleb.Id))
            .Returns(returnedPleb);

        await _handler.Handle(makePlebsDecisionCommand, CancellationToken.None);

        _memberRepositoryMock.Verify(r => r.Add(
                It.Is<Member>(m => NewMemberMatchesPleb(m, returnedPleb))),
            Times.Exactly(positiveDecisions.Count)
        );
    }

    private bool NewMemberMatchesPleb(Member member, Pleb pleb)
        => member.Username == pleb.RegistrationRequest.RequestedUsername
           && member.Password == pleb.RegistrationRequest.RequestedPassword
           && member.Role == Roles.NewcomerBaj;

    [Fact]
    public async Task HandleMakePlebsDecisions_WhenPositiveDecisionsFound_ShouldAddNewDecisionsToCorrespondingAdmin()
    {
        var returnedAdmin = AdminHandlersTestUtils.CreateAdmin();
        var returnedPleb = AdminHandlersTestUtils.CreatePleb();
        var positiveDecisions = AdminHandlersTestUtils.CreatePositiveDecisions(1)
            .ToList();
        var makePlebsDecisionCommand = new MakePlebsDecisionsCommand(positiveDecisions);

        _adminRepositoryMock.Setup(r => r.GetById(returnedAdmin.Id))
            .Returns(returnedAdmin);
        _plebRepositoryMock.Setup(r => r.GetById(returnedPleb.Id))
            .Returns(returnedPleb);

        await _handler.Handle(makePlebsDecisionCommand, CancellationToken.None);

        Assert.Contains(positiveDecisions.First(), returnedAdmin.Decisions);
    }

    [Fact]
    public async Task HandleMakePlebsDecisions_WhenNoPositiveDecisionsFound_ShouldNotCreateNewMembers()
    {
        var returnedAdmin = AdminHandlersTestUtils.CreateAdmin();
        var returnedPleb = AdminHandlersTestUtils.CreatePleb();
        var negativeDecisions = AdminHandlersTestUtils.CreateNegativeDecisions(1)
            .ToList();
        var makePlebsDecisionCommand = new MakePlebsDecisionsCommand(negativeDecisions);

        _adminRepositoryMock.Setup(r => r.GetById(returnedAdmin.Id))
            .Returns(returnedAdmin);
        _plebRepositoryMock.Setup(r => r.GetById(returnedPleb.Id))
            .Returns(returnedPleb);

        await _handler.Handle(makePlebsDecisionCommand, CancellationToken.None);

        _memberRepositoryMock.Verify(r => r.Add(It.IsAny<Member>()),
            Times.Never);
    }

    [Fact]
    public async Task
        HandleMakePlebsDecisions_WhenNoPositiveDecisionsFound_ShouldNotAddNewDecisionsToCorrespondingAdmin()
    {
        var returnedAdmin = AdminHandlersTestUtils.CreateAdmin();
        var returnedPleb = AdminHandlersTestUtils.CreatePleb();
        var negativeDecisions = AdminHandlersTestUtils.CreateNegativeDecisions(1)
            .ToList();
        var makePlebsDecisionCommand = new MakePlebsDecisionsCommand(negativeDecisions);

        _adminRepositoryMock.Setup(r => r.GetById(returnedAdmin.Id))
            .Returns(returnedAdmin);
        _plebRepositoryMock.Setup(r => r.GetById(returnedPleb.Id))
            .Returns(returnedPleb);

        await _handler.Handle(makePlebsDecisionCommand, CancellationToken.None);

        Assert.DoesNotContain(negativeDecisions.First(), returnedAdmin.Decisions);
    }
}
using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Plebs;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Domain.Plebs.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Admins.Commands;

public class MakePlebsDecisionsCommandHandler : IRequestHandler<MakePlebsDecisionsCommand>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly IPlebRepository _plebRepository;

    public MakePlebsDecisionsCommandHandler(
        IMemberRepository memberRepository,
        IAdminRepository adminRepository,
        IPlebRepository plebRepository)
    {
        _memberRepository = memberRepository;
        _adminRepository = adminRepository;
        _plebRepository = plebRepository;
    }

    public Task Handle(MakePlebsDecisionsCommand request, CancellationToken cancellationToken)
    {
        var decisions = request.Decisions.ToList();
        var positiveDecisions = decisions.Where(d => d.IsAccepted);
        
        foreach (var decision in positiveDecisions)
        {
            var admin = _adminRepository.GetById(decision.AdminId);
            admin.AddDecision(decision);

            var pleb = _plebRepository.GetById(decision.PlebId);
            var member = GetMemberFromRegistrationRequest(pleb.RegistrationRequest);
            _memberRepository.Add(member);
        }

        return Task.CompletedTask;
    }
    private Member GetMemberFromRegistrationRequest(RegistrationRequest registrationRequest)
    {
        var username = registrationRequest.RequestedUsername;
        var password = registrationRequest.RequestedPassword;
        return Member.Create(Guid.NewGuid(), username, password, Roles.NewcomerBaj);
    }
}
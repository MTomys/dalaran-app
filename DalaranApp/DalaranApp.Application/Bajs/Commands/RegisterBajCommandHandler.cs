using DalaranApp.Application.Auth.Common;
using DalaranApp.Application.Common.Exceptions.Bajs;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Domain.Bajs;
using MediatR;

namespace DalaranApp.Application.Bajs.Commands;

public class RegisterBajCommandHandler : IRequestHandler<RegisterBajCommand, AuthenticationResponse>
{
    private readonly IBajRepository _bajRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IJwtTokenProvider _tokenProvider;

    public RegisterBajCommandHandler(IBajRepository bajRepository, IMemberRepository memberRepository,
        IJwtTokenProvider tokenProvider)
    {
        _bajRepository = bajRepository;
        _memberRepository = memberRepository;
        _tokenProvider = tokenProvider;
    }

    public async Task<AuthenticationResponse> Handle(RegisterBajCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var (memberId, profileName) = request;
        if (_bajRepository.ExistsWithProfileName(profileName))
        {
            throw new BajUsernameAlreadyTakenException();
        }

        var newcomerBajCredentials = _memberRepository.GetById(Guid.Parse(memberId));
        var newBajMember = CreateMemberBajFromNewcomerBaj(newcomerBajCredentials);
        
        var newBaj = Baj.Create(profileName, newBajMember.Id);
        _bajRepository.Save(newBaj);
        
        _memberRepository.Delete(Guid.Parse(memberId));
        _memberRepository.Save(newBajMember);
        
        var token = _tokenProvider.Generate(newBajMember);
        return new AuthenticationResponse(profileName, token, Roles.Baj);
    }

    private static Member CreateMemberBajFromNewcomerBaj(Member newcomerBajCredentials)
    {
        return Member.Create(Guid.NewGuid(),
            newcomerBajCredentials.Username,
            newcomerBajCredentials.Password,
            Roles.Baj);
    }
}
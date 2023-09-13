using DalaranApp.Application.Auth.Common;
using DalaranApp.Application.Common.Exceptions.Bajs;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;
using DalaranApp.Domain.Bajs;
using MediatR;

namespace DalaranApp.Application.Bajs.Commands;

public class RegisterNewcomerBajCommandHandler : IRequestHandler<RegisterNewcomerBajCommand, AuthenticationResponse>
{
    private readonly IBajRepository _bajRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IJwtTokenProvider _tokenProvider;

    public RegisterNewcomerBajCommandHandler(IBajRepository bajRepository, IMemberRepository memberRepository,
        IJwtTokenProvider tokenProvider)
    {
        _bajRepository = bajRepository;
        _memberRepository = memberRepository;
        _tokenProvider = tokenProvider;
    }

    public async Task<AuthenticationResponse> Handle(RegisterNewcomerBajCommand request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var (memberId, profileName) = request;
        if (_bajRepository.ExistsWithProfileName(profileName))
        {
            throw new BajUsernameAlreadyTakenException();
        }

        var existingMember = _memberRepository.GetById(memberId);
        var newBajMember = CreateMemberBajFromNewcomerBaj(existingMember);
        _memberRepository.Update(newBajMember);

        var newBaj = Baj.Create(profileName, newBajMember.Id);
        _bajRepository.Save(newBaj);

        var token = _tokenProvider.Generate(newBajMember);
        return new AuthenticationResponse(profileName, token, Roles.Baj);
    }

    private Member CreateMemberBajFromNewcomerBaj(Member newcomerBajCredentials)
    {
        return Member.Create(
            newcomerBajCredentials.Id,
            newcomerBajCredentials.Username,
            newcomerBajCredentials.Password,
            Roles.Baj);
    }
}
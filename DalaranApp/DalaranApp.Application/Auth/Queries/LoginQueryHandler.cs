using DalaranApp.Application.Auth.Common;
using DalaranApp.Application.Common.Exceptions.Members;
using DalaranApp.Application.Common.Interfaces.Auth;
using MediatR;

namespace DalaranApp.Application.Auth.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResponse>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IJwtTokenProvider _tokenProvider;

    public LoginQueryHandler(IMemberRepository memberRepository, IJwtTokenProvider tokenProvider)
    {
        _memberRepository = memberRepository;
        _tokenProvider = tokenProvider;
    }

    public async Task<AuthenticationResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var member = _memberRepository.GetMember(query.Username, query.Password);

        if (member is null)
        {
            throw new InvalidMemberCredentialsException();
        }

        var token = _tokenProvider.Generate(member);
        
        return new AuthenticationResponse(member.Username, token);
    }
}
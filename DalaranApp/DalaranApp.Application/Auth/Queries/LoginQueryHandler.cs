using DalaranApp.Application.Auth.Common;
using DalaranApp.Application.Common.Exceptions.Members;
using DalaranApp.Application.Common.Interfaces.Auth;
using MediatR;

namespace DalaranApp.Application.Auth.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResponse>
{
    private readonly IMemberRepository _memberRepository;

    public LoginQueryHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<AuthenticationResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var member = _memberRepository.GetByUsername(query.Username);
        
        if (member is null)
        {
            throw new InvalidMemberCredentialsException();
        }

        if (member.Password != query.Password)
        {
            throw new InvalidMemberCredentialsException();
        }

        return new AuthenticationResponse("asd", "asd");
    }
}
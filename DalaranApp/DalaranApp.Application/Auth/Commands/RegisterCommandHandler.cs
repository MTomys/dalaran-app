using DalaranApp.Application.Auth.Common;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth.Entities;
using DalaranApp.Domain.Auth.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Auth.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegistrationResponse>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IJwtTokenProvider _jwtTokenProvider;

    public RegisterCommandHandler(IMemberRepository memberRepository, IJwtTokenProvider jwtTokenProvider)
    {
        _memberRepository = memberRepository;
        _jwtTokenProvider = jwtTokenProvider;
    }

    public async Task<RegistrationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var member = new Member { Username = request.Username, Password = request.Password };
        _memberRepository.Save(member);

        var token = _jwtTokenProvider.Generate(member);
        var passphrase = new SecretPassphrase();

        return new RegistrationResponse(token, passphrase);
    }
}
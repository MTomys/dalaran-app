using DalaranApp.Application.Auth.Common;
using MediatR;

namespace DalaranApp.Application.Bajs.Commands;

public class RegisterBajCommandHandler: IRequestHandler<RegisterBajCommand, AuthenticationResponse>
{
    public Task<AuthenticationResponse> Handle(RegisterBajCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
using DalaranApp.Application.Auth.Common;
using MediatR;

namespace DalaranApp.Application.Auth.Queries;

public record LoginQuery(
    string Username,
    string Password
    ) : IRequest<AuthenticationResponse>;
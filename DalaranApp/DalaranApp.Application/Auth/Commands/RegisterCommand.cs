using DalaranApp.Application.Auth.Common;
using MediatR;

namespace DalaranApp.Application.Auth.Commands;

public record RegisterCommand() : IRequest<AuthenticationResponse>;
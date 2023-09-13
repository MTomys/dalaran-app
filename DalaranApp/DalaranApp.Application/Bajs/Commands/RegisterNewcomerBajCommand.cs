using DalaranApp.Application.Auth.Common;
using MediatR;

namespace DalaranApp.Application.Bajs.Commands;

public record RegisterNewcomerBajCommand(Guid MemberId, string NewcomerBajProfileName) : IRequest<AuthenticationResponse>;
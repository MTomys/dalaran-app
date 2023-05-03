using DalaranApp.Application.Auth.Common;
using MediatR;

namespace DalaranApp.Application.Bajs.Commands;

public record RegisterBajCommand(string MemberId, string NewcomerBajProfileName) : IRequest<AuthenticationResponse>;
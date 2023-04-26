using DalaranApp.Application.Auth.Common;
using MediatR;

namespace DalaranApp.Application.Bajs.Commands;

public record RegisterBajCommand(): IRequest<AuthenticationResponse>;
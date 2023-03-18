using DalaranApp.Application.Auth.Common;
using MediatR;

namespace DalaranApp.Application.Plebs.Registration;

public record RegisterCommand(string Username, string Password, string RequestMessage) 
    : IRequest<RegistrationResponse>;
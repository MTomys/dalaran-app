using MediatR;

namespace DalaranApp.Application.Plebs.Registration;

public record RegisterCommand(string Username, string Password, string SecretPassphrase, string RequestMessage) 
    : IRequest<RegistrationResponse>;
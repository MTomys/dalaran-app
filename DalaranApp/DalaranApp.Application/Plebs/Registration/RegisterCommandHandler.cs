using DalaranApp.Application.Auth.Constants;
using DalaranApp.Application.Common.Interfaces.Plebs;
using DalaranApp.Domain.DomainEvents;
using DalaranApp.Domain.Plebs;
using DalaranApp.Domain.Plebs.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Plebs.Registration;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegistrationResponse>
{
    private readonly IPlebRepository _plebRepository;
    private readonly IPublisher _publisher;

    public RegisterCommandHandler(IPlebRepository plebRepository, IPublisher publisher)
    {
        _plebRepository = plebRepository;
        _publisher = publisher;
    }

    public async Task<RegistrationResponse> Handle(
        RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        const string registrationResponseMessage = "Your registration request has been submitted, please wait for the admins to approve your request.";

        if (request.SecretPassphrase != AuthConstants.SECRET_PASSPHRASE_VALUE)
        {
            return new RegistrationResponse(registrationResponseMessage);
        }

        var registrationRequest = new RegistrationRequest(
            DateTime.Now,
            request.Username,
            request.Password,
            request.RequestMessage);

        var pleb = Pleb.Create(registrationRequest);

        await _publisher.Publish(new PlebRegisteredDomainEvent(pleb), cancellationToken);

        _plebRepository.Save(pleb);

        return new RegistrationResponse(
            registrationResponseMessage);
    }
}
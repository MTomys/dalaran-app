using DalaranApp.Application.Common.Interfaces.Plebs;
using DalaranApp.Domain.Plebs;
using DalaranApp.Domain.Plebs.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Plebs.Registration;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegistrationResponse>
{
    private readonly IPlebRepository _plebRepository;

    public RegisterCommandHandler(IPlebRepository plebRepository)
    {
        _plebRepository = plebRepository;
    }

    public async Task<RegistrationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var registrationRequest = new RegistrationRequest(
            DateTime.Now,
            request.Username,
            request.Password,
            request.RequestMessage);

        var pleb = Pleb.Create(registrationRequest);

        pleb.RequestRegistration();

        _plebRepository.Save(pleb);

        return new RegistrationResponse(
            "Your registration request has been submitted, please wait for the admin to approve your request.");
    }
}
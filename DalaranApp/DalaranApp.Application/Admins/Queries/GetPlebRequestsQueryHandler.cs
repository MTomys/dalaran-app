using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Domain.Admins.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Admins.Queries;

public class GetPlebRequestsQueryHandler : IRequestHandler<GetPlebsQuery, IEnumerable<PlebRegistrationRequest>>
{
    private readonly IAdminRepository _adminRepository;

    public GetPlebRequestsQueryHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<IEnumerable<PlebRegistrationRequest>> Handle(GetPlebsQuery request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var admin = _adminRepository.GetById(request.AdminId);
        var plebRequests = admin.PlebRegistrationRequests;

        return plebRequests;
    }
}
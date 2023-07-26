using DalaranApp.Application.Bajs.Common;
using DalaranApp.Application.Common.Interfaces.Bajs;
using MediatR;

namespace DalaranApp.Application.Bajs.Queries;

public record GetBajMeQueryHandler : IRequestHandler<GetBajMeQuery, BajMe>
{
    private readonly IBajRepository _bajRepository;

    public GetBajMeQueryHandler(IBajRepository bajRepository)
    {
        _bajRepository = bajRepository;
    }

    public Task<BajMe> Handle(GetBajMeQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
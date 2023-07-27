using DalaranApp.Application.Bajs.Common;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Bajs;
using MediatR;

namespace DalaranApp.Application.Bajs.Queries;

public record GetBajMeQueryHandler : IRequestHandler<GetBajMeQuery, BajMe>
{
    private readonly IBajRepository _bajRepository;

    public GetBajMeQueryHandler(IBajRepository bajRepository, IMemberRepository memberRepository)
    {
        _bajRepository = bajRepository;
    }

    public async Task<BajMe> Handle(GetBajMeQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var baj = _bajRepository.GetById(request.BajId);
        return new BajMe(baj.ProfilePicture, baj.ProfileName, baj.Id);
    }
}
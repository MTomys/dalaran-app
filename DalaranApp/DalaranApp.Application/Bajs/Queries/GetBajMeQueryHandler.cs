using DalaranApp.Application.Bajs.Common;
using DalaranApp.Application.Common.Exceptions.Bajs;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Domain.Auth.Common;
using MediatR;

namespace DalaranApp.Application.Bajs.Queries;

public record GetBajMeQueryHandler : IRequestHandler<GetBajMeQuery, BajMe>
{
    private readonly IBajRepository _bajRepository;
    private readonly IMemberRepository _memberRepository;

    public GetBajMeQueryHandler(IBajRepository bajRepository, IMemberRepository memberRepository)
    {
        _bajRepository = bajRepository;
        _memberRepository = memberRepository;
    }

    public async Task<BajMe> Handle(GetBajMeQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var member = _memberRepository.GetById(request.BajId);

        if (member.Role != Roles.Baj)
        {
            throw new InvalidBajMeRequestException();
        }

        var baj = _bajRepository.GetById(request.BajId);

        return new BajMe(baj.ProfilePicture, baj.ProfileName, baj.Id);
    }
}
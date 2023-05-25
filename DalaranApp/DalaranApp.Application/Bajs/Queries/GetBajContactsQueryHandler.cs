using DalaranApp.Application.Bajs.Common;
using DalaranApp.Application.Common.Interfaces.Bajs;
using MediatR;

namespace DalaranApp.Application.Bajs.Queries;

public class GetBajContactsQueryHandler: IRequestHandler<GetBajContactsQuery, IEnumerable<BajContact>>
{
    private readonly IBajRepository _bajRepository;

    public GetBajContactsQueryHandler(IBajRepository bajRepository)
    {
        _bajRepository = bajRepository;
    }

    public Task<IEnumerable<BajContact>> Handle(GetBajContactsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
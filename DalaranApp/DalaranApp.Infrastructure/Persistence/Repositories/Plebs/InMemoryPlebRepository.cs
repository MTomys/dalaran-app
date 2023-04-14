using DalaranApp.Application.Common.Interfaces.Plebs;
using DalaranApp.Domain.Plebs;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Plebs;

public class InMemoryPlebRepository : IPlebRepository
{
    private readonly List<Pleb> _plebs = new();

    public void Save(Pleb pleb)
    {
        _plebs.Add(pleb);
    }

    public Pleb GetById(Guid plebId)
    {
        return _plebs.First(p => p.Id == plebId);
    }

    public IReadOnlyCollection<Pleb> GetPlebs()
    {
        return _plebs.AsReadOnly();
    }
}
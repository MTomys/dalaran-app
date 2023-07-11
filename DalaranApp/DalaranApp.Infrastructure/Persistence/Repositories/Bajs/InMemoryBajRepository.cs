using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Domain.Bajs;
using DalaranApp.Infrastructure.DataSeed;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Bajs;

public class InMemoryBajRepository : IBajRepository
{
    private readonly List<Baj> _bajs = BajDataSeed.GenerateBajs();

    public Baj GetById(Guid id)
    {
        return _bajs.First(b => b.Id == id);
    }

    public void Save(Baj baj)
    {
        _bajs.Add(baj);
    }

    public bool ExistsWithId(Guid id)
    {
        return _bajs.Any(b => b.Id == id);
    }

    public bool ExistsWithProfileName(string profileName)
    {
        return _bajs.Any(b => b.ProfileName == profileName);
    }

    public IEnumerable<Baj> GetManyById(IEnumerable<Guid> ids)
    {
        return _bajs.FindAll()
    }
}
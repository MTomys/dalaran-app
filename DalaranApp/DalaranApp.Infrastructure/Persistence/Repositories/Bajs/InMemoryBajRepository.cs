using DalaranApp.Application.Common.Interfaces.Bajs;
using DalaranApp.Domain.Bajs;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Bajs;

public class InMemoryBajRepository : IBajRepository
{
    public Baj GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Save(Baj baj)
    {
        throw new NotImplementedException();
    }

    public bool DoesExist(Guid id)
    {
        throw new NotImplementedException();
    }
}
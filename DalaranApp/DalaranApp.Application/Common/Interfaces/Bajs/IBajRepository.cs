using DalaranApp.Domain.Bajs;

namespace DalaranApp.Application.Common.Interfaces.Bajs;

public interface IBajRepository
{
    Baj GetById(Guid id);
    void Save(Baj baj);
    void Update(Baj newBaj);
    bool ExistsWithId(Guid id);
    bool ExistsWithProfileName(string profileName);
    public IEnumerable<Baj> GetManyById(IEnumerable<Guid> ids);
}
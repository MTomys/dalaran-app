using DalaranApp.Domain.Bajs;

namespace DalaranApp.Application.Common.Interfaces.Bajs;

public interface IBajRepository
{
    Baj GetById(Guid id);
    void Save(Baj baj);
}
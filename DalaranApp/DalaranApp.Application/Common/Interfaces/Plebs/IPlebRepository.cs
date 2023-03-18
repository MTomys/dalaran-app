using DalaranApp.Domain.Plebs;

namespace DalaranApp.Application.Common.Interfaces.Plebs;

public interface IPlebRepository
{
    void Save(Pleb pleb);
}
using DalaranApp.Domain.Pleb;

namespace DalaranApp.Application.Common.Interfaces.Plebs;

public interface IPlebRepository
{
    void Save(Pleb pleb);
}
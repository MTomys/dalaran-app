using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Domain.Admins;
using DalaranApp.Infrastructure.DataSeed;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Admins;

public class InMemoryAdminRepository : IAdminRepository
{
    private readonly List<Admin> _admins = AdminDataSeed.GenerateAdmins();

    public List<Admin> GetAdmins()
    {
        return _admins;
    }

    public Admin GetById(Guid id)
    {
        return _admins.First(admin => admin.Id == id);
    }
}
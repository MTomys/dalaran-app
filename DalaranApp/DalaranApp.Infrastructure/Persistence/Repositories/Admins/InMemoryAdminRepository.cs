using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Domain.Admins;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Admins;

public class InMemoryAdminRepository : IAdminRepository
{
    private readonly List<Admin> _admins = new()
    {
        Admin.Create("admin", Guid.Parse("00000000-1234-0000-0000-000000000000"))
    };

    public List<Admin> GetAdmins()
    {
        return _admins;
    }

    public Admin GetById(Guid id)
    {
        return _admins.First(admin => admin.Id == id);
    }
}
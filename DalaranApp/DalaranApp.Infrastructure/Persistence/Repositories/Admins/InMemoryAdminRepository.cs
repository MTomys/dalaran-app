using DalaranApp.Application.Common.Interfaces.Admins;
using DalaranApp.Domain.Admins;

namespace DalaranApp.Infrastructure.Persistence.Repositories.Admins;

public class InMemoryAdminRepository : IAdminRepository
{
    private readonly List<Admin> _admins = new List<Admin>()
    {
        new Admin()
    };
    
    public List<Admin> GetAdmins()
    {
        return _admins;
    }
}
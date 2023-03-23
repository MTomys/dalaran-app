using DalaranApp.Domain.Admins;

namespace DalaranApp.Application.Common.Interfaces.Admins;

public interface IAdminRepository
{
    List<Admin> GetAdmins();
    Admin GetById(Guid id);
}
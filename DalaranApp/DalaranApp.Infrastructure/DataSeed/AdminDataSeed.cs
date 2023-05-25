using DalaranApp.Domain.Admins;

namespace DalaranApp.Infrastructure.DataSeed;

public class AdminDataSeed
{
    public static List<Admin> GenerateAdmins()
    {
        var admins = new List<Admin>()
        {
            Admin.Create("admin", Guid.Parse("00000000-0000-0000-0000-100000000001"))
        };

        return admins;
    }
}
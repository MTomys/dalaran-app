using DalaranApp.Domain.Auth;
using DalaranApp.Domain.Auth.Common;

namespace DalaranApp.Infrastructure.DataSeed;

public class MemberDataSeed
{
    public static List<Member> GenerateMembers()
    {
        var members = new List<Member>()
        {
            Member.Create(Guid.Parse("00000000-0000-0000-0000-100000000001"), "admin", "p", Roles.Admin),
            Member.Create(Guid.Parse("00000000-0000-0000-0000-200000000001"), "biggdawg", "p", Roles.Baj),
            Member.Create(Guid.Parse("00000000-0000-0000-0000-200000000002"), "funkyfish", "p", Roles.Baj),
            Member.Create(Guid.Parse("00000000-0000-0000-0000-200000000003"), "jazzyjaguar", "p", Roles.Baj),
            Member.Create(Guid.Parse("00000000-0000-0000-0000-300000000001"), "newcomer", "p", Roles.NewcomerBaj),
        };

        return members;
    }
}
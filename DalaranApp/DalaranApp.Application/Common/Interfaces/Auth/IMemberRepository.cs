using DalaranApp.Domain.Auth;

namespace DalaranApp.Application.Common.Interfaces.Auth;

public interface IMemberRepository
{
    Member? GetByUsernameAndPassword(string username, string password);
    Member GetById(Guid id);
    Member Save(Member member);
    void Delete(Guid id);
}
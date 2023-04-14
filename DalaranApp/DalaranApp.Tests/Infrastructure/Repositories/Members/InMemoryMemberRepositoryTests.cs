using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth;
using DalaranApp.Infrastructure.Persistence.Repositories.Members;

namespace DalaranApp.Tests.Infrastructure.Repositories.Members;

public class InMemoryMemberRepositoryTests
{
    private readonly IMemberRepository _memberRepository;

    public InMemoryMemberRepositoryTests()
    {
        _memberRepository = new InMemoryMemberRepository();
    }

    [Fact]
    public void GetByUsername_ReturnsNull_WhenMemberNotFound()
    {
        var result = _memberRepository.GetMember("nonexistingusername", "nonexistingpassword");
        
        Assert.Null(result);
    }

    [Fact]
    public void GetByUsername_ReturnsMember_WhenMemberWithGivenUsernameAndPasswordIsFound()
    {
        var member = new Member(Guid.Empty,"username", "password", "");
        _memberRepository.Save(member);

        var result = _memberRepository.GetMember("username", "password")!;

        Assert.Equal(member.Username, result.Username);
        Assert.Equal(member.Password, result.Password);
    }
}
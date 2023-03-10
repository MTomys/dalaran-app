using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth.Entities;
using DalaranApp.Infrastructure.Persistence.Repositories.Members;

namespace DalaranApp.Tests.Infrastructure.Repositories.Members;

public class InMemoryMemberRepositoryTests
{
    private readonly IMemberRepository _memberRepository = new InMemoryMemberRepository();
    
    [Fact]
    public void GetByUsername_ReturnsNull_WhenMemberNotFound()
    {
        var result = _memberRepository.GetByUsername("");

        Assert.Null(result);
    }

    [Fact]
    public void GetByUsername_ReturnsMember_WhenMemberWithGivenUsernameIsPresent()
    {
        var member = new Member() { Username = "username", Password = "password" };
        _memberRepository.Save(member);

        var result = _memberRepository.GetByUsername(member.Username)!;

        Assert.Equal(member.Username, result.Username);
        Assert.Equal(member.Password, result.Password);
    }
}
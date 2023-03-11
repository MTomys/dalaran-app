using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DalaranApp.Application.Common.Interfaces.Auth;
using DalaranApp.Domain.Auth.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DalaranApp.Infrastructure.Auth;

public class JwtTokenProvider : IJwtTokenProvider
{
    private readonly JwtOptions _jwtOptions;

    public JwtTokenProvider(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public string Generate(Member member)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, member.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, member.Username),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials
        );

        var tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }
}
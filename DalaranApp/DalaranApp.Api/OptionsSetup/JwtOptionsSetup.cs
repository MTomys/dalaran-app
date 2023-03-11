using DalaranApp.Infrastructure.Auth;
using Microsoft.Extensions.Options;

namespace DalaranApp.Api.OptionsSetup;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private const string _sectionName = "JWT";
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(nameof(JwtOptions)).Bind(options);

    }
}
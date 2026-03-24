using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using SdlcAutomation.Domain.Constants;

namespace SdlcAutomation.Api.Auth;

public sealed class DevelopmentAuthHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder)
    : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var identity = new ClaimsIdentity(
        [
            new Claim(ClaimTypes.NameIdentifier, "local-user"),
            new Claim(ClaimTypes.Name, "Local User")
        ],
        AppConstants.DefaultAuthScheme);

        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, AppConstants.DefaultAuthScheme);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}

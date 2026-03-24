using Microsoft.Extensions.Logging;
using SdlcAutomation.Application.Abstractions;

namespace SdlcAutomation.Infrastructure.Integrations;

public sealed class GitHubClient(ILogger<GitHubClient> logger) : IGitHubIntegrationService
{
    public Task PollAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Polling GitHub integration endpoint");
        return Task.CompletedTask;
    }
}

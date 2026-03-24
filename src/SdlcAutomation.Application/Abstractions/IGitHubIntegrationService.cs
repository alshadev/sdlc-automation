namespace SdlcAutomation.Application.Abstractions;

public interface IGitHubIntegrationService
{
    Task PollAsync(CancellationToken cancellationToken);
}

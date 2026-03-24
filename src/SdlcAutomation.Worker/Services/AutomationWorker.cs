using SdlcAutomation.Application.Abstractions;

namespace SdlcAutomation.Worker.Services;

public sealed class AutomationWorker(
    ILogger<AutomationWorker> logger,
    IPubSubConsumer pubSubConsumer,
    IGitHubIntegrationService gitHubIntegrationService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.WhenAll(
                pubSubConsumer.ConsumeAsync(stoppingToken),
                gitHubIntegrationService.PollAsync(stoppingToken));

            logger.LogInformation("Automation worker iteration completed at {TimeUtc}", DateTimeOffset.UtcNow);
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}

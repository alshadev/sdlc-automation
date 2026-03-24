using Microsoft.Extensions.Logging;
using SdlcAutomation.Application.Abstractions;

namespace SdlcAutomation.Infrastructure.Integrations;

public sealed class PubSubConsumer(ILogger<PubSubConsumer> logger) : IPubSubConsumer
{
    public Task ConsumeAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Consuming Pub/Sub messages");
        return Task.CompletedTask;
    }
}

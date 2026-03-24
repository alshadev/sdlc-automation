namespace SdlcAutomation.Application.Abstractions;

public interface IPubSubConsumer
{
    Task ConsumeAsync(CancellationToken cancellationToken);
}

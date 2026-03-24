namespace SdlcAutomation.Application.Abstractions;

public interface IRagOrchestrator
{
    Task<IReadOnlyCollection<string>> RetrieveContextAsync(string query, CancellationToken cancellationToken);
}

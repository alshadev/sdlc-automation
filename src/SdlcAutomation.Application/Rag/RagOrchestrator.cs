using SdlcAutomation.Application.Abstractions;

namespace SdlcAutomation.Application.Rag;

public sealed class RagOrchestrator : IRagOrchestrator
{
    public Task<IReadOnlyCollection<string>> RetrieveContextAsync(string query, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<string> empty = [];
        return Task.FromResult(empty);
    }
}

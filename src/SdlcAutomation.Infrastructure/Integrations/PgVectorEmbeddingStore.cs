namespace SdlcAutomation.Infrastructure.Integrations;

public sealed class PgVectorEmbeddingStore
{
    public Task StoreAsync(string documentId, ReadOnlyMemory<float> embedding, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

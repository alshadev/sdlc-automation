namespace SdlcAutomation.Infrastructure.Integrations;

public sealed class VertexAiClient
{
    public Task<string> GenerateAsync(string prompt, CancellationToken cancellationToken)
    {
        return Task.FromResult(prompt);
    }
}

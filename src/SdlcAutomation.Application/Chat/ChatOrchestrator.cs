using SdlcAutomation.Application.Abstractions;

namespace SdlcAutomation.Application.Chat;

public sealed class ChatOrchestrator(IRagOrchestrator ragOrchestrator) : IChatOrchestrator
{
    public async Task<string> GetResponseAsync(ChatRequest request, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Prompt);

        var context = await ragOrchestrator.RetrieveContextAsync(request.Prompt, cancellationToken);
        return $"Received prompt ({request.Prompt.Length} chars). Context chunks: {context.Count}.";
    }
}

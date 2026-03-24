using SdlcAutomation.Application.Chat;

namespace SdlcAutomation.Application.Abstractions;

public interface IChatOrchestrator
{
    Task<string> GetResponseAsync(ChatRequest request, CancellationToken cancellationToken);
}

using SdlcAutomation.Application.Abstractions;
using SdlcAutomation.Application.Chat;

namespace SdlcAutomation.Application.Tests.Rag;

public sealed class ChatOrchestratorTests
{
    [Fact]
    public async Task GetResponseAsync_ReturnsResponseContainingContextCount()
    {
        var rag = new FakeRagOrchestrator();
        var sut = new ChatOrchestrator(rag);

        var result = await sut.GetResponseAsync(new ChatRequest("hello", "user-1"), CancellationToken.None);

        Assert.Contains("Context chunks: 2", result);
    }

    [Fact]
    public async Task GetResponseAsync_Throws_WhenPromptIsEmpty()
    {
        var rag = new FakeRagOrchestrator();
        var sut = new ChatOrchestrator(rag);

        await Assert.ThrowsAsync<ArgumentException>(() => sut.GetResponseAsync(new ChatRequest("", "user-1"), CancellationToken.None));
    }

    private sealed class FakeRagOrchestrator : IRagOrchestrator
    {
        public Task<IReadOnlyCollection<string>> RetrieveContextAsync(string query, CancellationToken cancellationToken)
        {
            IReadOnlyCollection<string> chunks = ["c1", "c2"];
            return Task.FromResult(chunks);
        }
    }
}

namespace SdlcAutomation.Domain.Entities;

public sealed class ChatSession
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string UserId { get; init; }

    public DateTimeOffset CreatedAtUtc { get; init; } = DateTimeOffset.UtcNow;
}

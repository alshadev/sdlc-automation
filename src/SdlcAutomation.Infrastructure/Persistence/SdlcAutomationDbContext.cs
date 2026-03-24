using Microsoft.EntityFrameworkCore;
using SdlcAutomation.Domain.Entities;

namespace SdlcAutomation.Infrastructure.Persistence;

public sealed class SdlcAutomationDbContext(DbContextOptions<SdlcAutomationDbContext> options) : DbContext(options)
{
    public DbSet<ChatSession> ChatSessions => Set<ChatSession>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ChatSession>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.UserId).HasMaxLength(256);
        });
    }
}

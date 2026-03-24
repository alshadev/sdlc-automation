using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SdlcAutomation.Application.Abstractions;
using SdlcAutomation.Infrastructure.Integrations;
using SdlcAutomation.Infrastructure.Persistence;

namespace SdlcAutomation.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<SdlcAutomationDbContext>(options => options.UseInMemoryDatabase("sdlc-automation"));
        services.AddSingleton<IGitHubIntegrationService, GitHubClient>();
        services.AddSingleton<IPubSubConsumer, PubSubConsumer>();
        services.AddScoped<PgVectorEmbeddingStore>();
        services.AddScoped<VertexAiClient>();

        return services;
    }
}

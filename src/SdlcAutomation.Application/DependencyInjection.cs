using Microsoft.Extensions.DependencyInjection;
using SdlcAutomation.Application.Abstractions;
using SdlcAutomation.Application.Chat;
using SdlcAutomation.Application.Rag;

namespace SdlcAutomation.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRagOrchestrator, RagOrchestrator>();
        services.AddScoped<IChatOrchestrator, ChatOrchestrator>();
        return services;
    }
}

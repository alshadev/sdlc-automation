using SdlcAutomation.Api.Auth;
using SdlcAutomation.Application;
using SdlcAutomation.Application.Abstractions;
using SdlcAutomation.Application.Chat;
using SdlcAutomation.Domain.Constants;
using SdlcAutomation.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(AppConstants.DefaultAuthScheme)
    .AddScheme<Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions, DevelopmentAuthHandler>(AppConstants.DefaultAuthScheme, _ => { });
builder.Services.AddAuthorization();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => Results.Ok(new { Name = "SdlcAutomation.Api", Status = "Healthy" }));

app.MapPost("/chat/stream", async (ChatRequest request, IChatOrchestrator chatOrchestrator, HttpContext context, CancellationToken cancellationToken) =>
{
    context.Response.Headers.ContentType = AppConstants.SseContentType;

    var response = await chatOrchestrator.GetResponseAsync(request, cancellationToken);
    await context.Response.WriteAsync($"event: message\n", cancellationToken);
    await context.Response.WriteAsync($"data: {response}\n\n", cancellationToken);
    await context.Response.Body.FlushAsync(cancellationToken);
}).RequireAuthorization();

app.Run();

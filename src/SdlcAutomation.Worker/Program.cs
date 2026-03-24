using SdlcAutomation.Application;
using SdlcAutomation.Infrastructure.DependencyInjection;
using SdlcAutomation.Worker.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddHostedService<AutomationWorker>();

var host = builder.Build();
host.Run();

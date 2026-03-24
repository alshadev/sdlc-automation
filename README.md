# sdlc-automation

Base .NET 10 solution scaffold for SDLC automation.

## Structure

- `src/SdlcAutomation.Api` - Minimal API entry point with SSE chat endpoint and auth scaffold
- `src/SdlcAutomation.Worker` - Background worker scaffold for Pub/Sub and GitHub integration
- `src/SdlcAutomation.Application` - Application contracts and orchestration scaffolding
- `src/SdlcAutomation.Domain` - Domain entities, enums, and constants
- `src/SdlcAutomation.Infrastructure` - Persistence and external integration scaffolding
- `tests/SdlcAutomation.Application.Tests` - Initial unit tests
- `deployments/` - Dockerfile and Terraform/GCP starter manifests

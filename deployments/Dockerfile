FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY SdlcAutomation.sln ./
COPY src/SdlcAutomation.Api/SdlcAutomation.Api.csproj src/SdlcAutomation.Api/
COPY src/SdlcAutomation.Application/SdlcAutomation.Application.csproj src/SdlcAutomation.Application/
COPY src/SdlcAutomation.Domain/SdlcAutomation.Domain.csproj src/SdlcAutomation.Domain/
COPY src/SdlcAutomation.Infrastructure/SdlcAutomation.Infrastructure.csproj src/SdlcAutomation.Infrastructure/
RUN dotnet restore src/SdlcAutomation.Api/SdlcAutomation.Api.csproj

COPY . .
RUN dotnet publish src/SdlcAutomation.Api/SdlcAutomation.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "SdlcAutomation.Api.dll"]

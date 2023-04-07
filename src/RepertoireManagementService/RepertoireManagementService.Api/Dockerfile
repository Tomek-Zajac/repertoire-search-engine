FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ./*.sln .
COPY ./src/RepertoireManagementService/RepertoireManagementService.Api/*.Api.csproj ./src/RepertoireManagementService/RepertoireManagementService.Api/
COPY ./src/Shared/Domain/*.csproj ./src/Shared/Domain/
COPY ./src/RepertoireManagementService/RepertoireManagementService.Infrastructure/*.Infrastructure.csproj ./src/RepertoireManagementService/RepertoireManagementService.Infrastructure/
COPY ./src/RepertoireManagementService/RepertoireManagementService.Application/*.Application.csproj ./src/RepertoireManagementService/RepertoireManagementService.Application/

RUN dotnet restore "src/RepertoireManagementService/RepertoireManagementService.Api/RepertoireManagementService.Api.csproj"

COPY src/RepertoireManagementService/RepertoireManagementService.Api/. ./src/RepertoireManagementService/RepertoireManagementService.Api/
COPY src/Shared/Domain/. ./src/Shared/Domain/
COPY src/RepertoireManagementService/RepertoireManagementService.Infrastructure/. ./src/RepertoireManagementService/RepertoireManagementService.Infrastructure/
COPY src/RepertoireManagementService/RepertoireManagementService.Application/. ./src/RepertoireManagementService/RepertoireManagementService.Application/

WORKDIR "/src/src/RepertoireManagementService/RepertoireManagementService.Api"
RUN dotnet build "RepertoireManagementService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RepertoireManagementService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RepertoireManagementService.Api.dll"]

# docker-compose -f "./compose/RepertoireSearchEngine/docker-compose.yml" -f "./compose/RepertoireSearchEngine/docker-compose.override.yml" up -d
# docker build -f Dockerfile -t test .

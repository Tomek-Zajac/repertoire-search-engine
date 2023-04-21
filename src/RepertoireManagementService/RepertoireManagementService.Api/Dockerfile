FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/RepertoireManagementService/RepertoireManagementService.Api/RepertoireManagementService.Api.csproj", "src/RepertoireManagementService/RepertoireManagementService.Api/"]
COPY ["src/Shared/Domain/Domain.csproj", "src/Shared/Domain/"]
COPY ["src/RepertoireManagementService/RepertoireManagementService.Infrastructure/RepertoireManagementService.Infrastructure.csproj", "src/RepertoireManagementService/RepertoireManagementService.Infrastructure/"]
COPY ["src/RepertoireManagementService/RepertoireManagementService.Application/RepertoireManagementService.Application.csproj", "src/RepertoireManagementService/RepertoireManagementService.Application/"]
RUN curl https://github.com/Tomek-Zajac/repertoire-search-engine/blob/master/src/RepertoireManagementService/RepertoireManagementService.Api/RepertoireManagementService.Api.csproj
RUN dotnet restore "src/RepertoireManagementService/RepertoireManagementService.Api/RepertoireManagementService.Api.csproj" --source https://api.nuget.org/v3/index.json
COPY . .
WORKDIR "/src/src/RepertoireManagementService/RepertoireManagementService.Api"
RUN dotnet build "RepertoireManagementService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RepertoireManagementService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RepertoireManagementService.Api.dll"]
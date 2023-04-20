FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/UserManagementService/UserManagementService.Api/UserManagementService.Api.csproj", "src/UserManagementService/UserManagementService.Api/"]
COPY ["src/UserManagementService/UserManaSgementService.Infrastructure/UserManagementService.Infrastructure.csproj", "src/UserManagementService/UserManagementService.Infrastructure/"]
COPY ["src/UserManagementService/UserManagementService.Application/UserManagementService.Application.csproj", "src/UserManagementService/UserManagementService.Application/"]
#RUN apt-get update && apt-get install -y curl
RUN curl -LJO https://github.com/Tomek-Zajac/repertoire-search-engine/archive/refs/heads/main.zip
RUN dotnet restore "src/UserManagementService/UserManagementService.Api/UserManagementService.Api.csproj"
COPY . .
WORKDIR "/src/src/UserManagementService/UserManagementService.Api"
RUN dotnet build "UserManagementService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserManagementService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagementService.Api.dll"]
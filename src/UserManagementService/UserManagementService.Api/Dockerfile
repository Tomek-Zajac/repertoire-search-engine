FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ./*.sln .
COPY src/UserManagementService/UserManagementService.Api/UserManagementService.Api.csproj ./src/UserManagementService/UserManagementService.Api/
COPY src/UserManagementService/UserManagementService.Infrastructure/UserManagementService.Infrastructure.csproj ./src/UserManagementService/UserManagementService.Infrastructure/
COPY src/UserManagementService/UserManagementService.Application/UserManagementService.Application.csproj ./src/UserManagementService/UserManagementService.Application/

RUN dotnet restore "src/UserManagementService/UserManagementService.Api/UserManagementService.Api.csproj"

COPY src/UserManagementService/UserManagementService.Api/. ./src/UserManagementService/UserManagementService.Api/
COPY src/UserManagementService/UserManagementService.Infrastructure/. ./src/UserManagementService/UserManagementService.Infrastructure/
COPY src/UserManagementService/UserManagementService.Application/. ./src/UserManagementService/UserManagementService.Application/

WORKDIR "/src/src/UserManagementService/UserManagementService.Api"
RUN dotnet build "UserManagementService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserManagementService.Api.csproj" -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagementService.Api.dll"]
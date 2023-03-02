FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM base AS build
WORKDIR /src

COPY src/UserManagementService/UserManagementService.Api/*.csproj ./src/UserManagementService/UserManagementService.Api/
COPY src/UserManagementService/UserManagementService.Application/*.csproj ./src/UserManagementService/UserManagementService.Application/
COPY src/UserManagementService/UserManagementService.Infrastructure/*.csproj ./src/UserManagementService/UserManagementService.Infrastructure/

FROM build AS publish
WORKDIR /src/src/UserManagementService/UserManagementService.Api
RUN dotnet publish --no-restore --no-build --configuration Release --output /app/publish -p:Version=${VERSION} -p:AssemblyVersion=${ASSEMBLY_VERSION} -p:FileVersion=${ASSEMBLY_VERSION}

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagement.Api.dll"]
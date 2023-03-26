FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM base AS build
WORKDIR /src

COPY src/RepertoireManagementService/RepertoireManagementService.Api/*.csproj ./src/RepertoireManagementService/RepertoireManagementService.Api/
COPY src/RepertoireManagementService/RepertoireManagementService.Application/*.csproj ./src/RepertoireManagementService/RepertoireManagementService.Application/
COPY src/RepertoireManagementService/RepertoireManagementService.Infrastructure/*.csproj ./src/RepertoireManagementService/RepertoireManagementService.Infrastructure/

FROM build AS publish
WORKDIR /src/src/RepertoireManagementService/RepertoireManagementService.Api
RUN dotnet publish --no-restore --no-build --configuration Release --output /app/publish -p:Version=${VERSION} -p:AssemblyVersion=${ASSEMBLY_VERSION} -p:FileVersion=${ASSEMBLY_VERSION}

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RepertoireManagement.Api.dll"]
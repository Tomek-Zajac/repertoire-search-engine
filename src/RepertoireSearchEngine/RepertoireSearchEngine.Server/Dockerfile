FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ./*.sln .
COPY src/RepertoireSearchEngine/RepertoireSearchEngine.Server/*.csproj ./src/RepertoireSearchEngine/RepertoireSearchEngine.Server/

RUN dotnet restore "src/RepertoireSearchEngine/RepertoireSearchEngine.Server/RepertoireSearchEngine.Server.csproj"

COPY src/RepertoireSearchEngine/RepertoireSearchEngine.Server/. ./src/RepertoireSearchEngine/RepertoireSearchEngine.Server/

WORKDIR "/src/src/RepertoireSearchEngine/RepertoireSearchEngine.Server"
RUN dotnet build "RepertoireSearchEngine.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RepertoireSearchEngine.Server.csproj" -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RepertoireSearchEngine.Server.dll"]
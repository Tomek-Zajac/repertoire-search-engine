FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/RepertoireSearchEngine/RepertoireSearchEngine.Server/RepertoireSearchEngine.Server.csproj", "src/RepertoireSearchEngine/RepertoireSearchEngine.Server/"]
RUN curl https://github.com/Tomek-Zajac/repertoire-search-engine/blob/master/src/RepertoireSearchEngine/RepertoireSearchEngine.Server/RepertoireSearchEngine.Server.csproj
RUN dotnet restore "src/RepertoireSearchEngine/RepertoireSearchEngine.Server/RepertoireSearchEngine.Server.csproj" --source https://github.com/Tomek-Zajac/repertoire-search-engine
COPY . .
WORKDIR "/src/src/RepertoireSearchEngine/RepertoireSearchEngine.Server"
RUN dotnet build "RepertoireSearchEngine.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RepertoireSearchEngine.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RepertoireSearchEngine.Server.dll"]
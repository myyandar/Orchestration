# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Orchestration.API/Orchestration.API.csproj", "Orchestration.API/"]
RUN dotnet restore "Orchestration.API/Orchestration.API.csproj"
COPY . .
WORKDIR "/src/Orchestration.API"
RUN dotnet build "Orchestration.API.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "Orchestration.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Orchestration.API.dll"]

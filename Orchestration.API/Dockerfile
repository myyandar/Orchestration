# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY Orchestration.API.csproj .
RUN dotnet restore "Orchestration.API.csproj"

# Copy everything else
COPY . .
RUN dotnet build "Orchestration.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Orchestration.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Orchestration.API.dll"]

# =========================
# Base runtime image
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# =========================
# Build stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project file and restore dependencies
COPY ["commITM2.csproj", "."]
RUN dotnet restore "./commITM2.csproj"

# Copy all source files and build
COPY . .
RUN dotnet build "./commITM2.csproj" -c $BUILD_CONFIGURATION -o /app/build

# =========================
# Publish stage
# =========================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./commITM2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# =========================
# Final runtime image
# =========================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Run the application
ENTRYPOINT ["dotnet", "commITM2.dll"]

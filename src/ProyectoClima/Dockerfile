# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG GITVERSION=0.0.1
ARG MAJOR_MINOR_PATCH=0.0.1


WORKDIR /src
COPY ["ProyectoClima/ProyectoClima.csproj", "ProyectoClima/"]
COPY ["Aplication/Aplication.csproj", "Aplication/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infraestructure/Infraestructure.csproj", "Infraestructure/"]
RUN dotnet restore "./ProyectoClima/ProyectoClima.csproj"
COPY . .
WORKDIR "/src/ProyectoClima"
RUN dotnet build "./ProyectoClima.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProyectoClima.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProyectoClima.dll"]
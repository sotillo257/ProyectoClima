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
COPY ["Directory.Build.props", "."]
COPY ["src/ProyectoClima/ProyectoClima.csproj", "src/ProyectoClima/"]
COPY ["src/Aplication/Aplication.csproj", "src/Aplication/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Infraestructure/Infraestructure.csproj", "src/Infraestructure/"]
RUN dotnet restore "./src/ProyectoClima/ProyectoClima.csproj"
COPY . .
WORKDIR "/src/src/ProyectoClima"
RUN dotnet build "./ProyectoClima.csproj" --no-restore -c $BUILD_CONFIGURATION -o /app/build /p:Version=$GITVERSION /p:FileVersion=$MAJOR_MINOR_PATCH /p:AssemblyVersion=$MAJOR_MINOR_PATCH

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProyectoClima.csproj" --no-restore -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false /p:Version=$GITVERSION /p:FileVersion=$MAJOR_MINOR_PATCH /p:AssemblyVersion=$MAJOR_MINOR_PATCH

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProyectoClima.dll"]
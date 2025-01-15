#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TiendaServicios.api.Autor/TiendaServicios.api.Autor.csproj", "TiendaServicios.api.Autor/"]
RUN dotnet restore "./TiendaServicios.api.Autor/TiendaServicios.api.Autor.csproj"
COPY . .
WORKDIR "/src/TiendaServicios.api.Autor"
RUN dotnet build "./TiendaServicios.api.Autor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TiendaServicios.api.Autor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TiendaServicios.api.Autor.dll"]
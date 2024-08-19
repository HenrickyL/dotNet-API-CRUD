#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Usando a imagem oficial do runtime do .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80  # Alterar para 8080 se preferir

# Usando a imagem oficial do SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StudentApi.csproj", "."]
RUN dotnet restore "./StudentApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./StudentApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicando a aplicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StudentApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Configurando a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentApi.dll"]

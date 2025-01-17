# 1. Base Image - çalışma mühiti (ASP.NET Core Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Build Image - layihəni tərtib etmək üçün
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Projeyi kopyalayın ve restore işlemini yapın
COPY ./MusicService.Web-API/MusicService.Web-API.csproj ./MusicService.Web-API/
RUN dotnet restore "MusicService.Web-API/MusicService.Web-API.csproj"

# Diğer dosyaları kopyalayın ve projeyi build edin
COPY . . 
WORKDIR "/src/MusicService.Web-API"
RUN dotnet build "./MusicService.Web-API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3. Publish Image - yayınlama işlemi
FROM build AS publish
RUN dotnet publish "./MusicService.Web-API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# 4. Final Image - çalışma ortamını ayarlayın
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicService.Web-API.dll"]



# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#
## Этот этап используется для сборки проекта службы
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["MusicService.Web-API/MusicService.Web-API.csproj", "MusicService.Web-API/"]
#RUN dotnet restore "./MusicService.Web-API/MusicService.Web-API.csproj"
#COPY . .
#WORKDIR "/src/MusicService.Web-API"
#RUN dotnet build "./MusicService.Web-API.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
## Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./MusicService.Web-API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
## Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MusicService.Web-API.dll"]
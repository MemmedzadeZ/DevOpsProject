 #Bu mərhələ, .NET 8.0 SDK ilə tətbiqinizi inşa edir
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["IdentityService.Web-API/IdentityService.Web-API.csproj", "IdentityService.Web-API/"]
#RUN dotnet restore "./IdentityService.Web-API/IdentityService.Web-API.csproj"
#COPY . . 
#WORKDIR "/src/IdentityService.Web-API"
#RUN dotnet build "./IdentityService.Web-API.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
## Bu mərhələ tətbiqi yayımlayır
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./IdentityService.Web-API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
## Bu mərhələ tətbiqin işlədiyi mühit üçün istifadə olunur
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#WORKDIR /app
#COPY --from=publish /app/publish . 
#ENTRYPOINT ["dotnet", "IdentityService.Web-API.dll"]

# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# 1. Base Image - çalışma mühiti
# 1. Base Image - çalışma mühiti (ASP.NET Core Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Build aşaması - .NET SDK ile projeyi derleyip yayınlama
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Projeyi kopyalayın ve restore işlemini yapın
COPY ./IdentityService.Web-API/IdentityService.Web-API.csproj ./IdentityService.Web-API/
RUN dotnet restore "IdentityService.Web-API/IdentityService.Web-API.csproj"

# Diğer dosyaları kopyalayın ve projeyi build edin
COPY . . 
WORKDIR "/src/IdentityService.Web-API"
RUN dotnet build "./IdentityService.Web-API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3. Publish aşaması - yayınlama işlemi
FROM build AS publish
RUN dotnet publish "./IdentityService.Web-API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4. Final aşama - yayınlanan dosyaları alıp, çalıştırılabilir hale getirme
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Uygulamayı başlatma
ENTRYPOINT ["dotnet", "IdentityService.Web-API.dll"]




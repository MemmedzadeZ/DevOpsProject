# 1. Base Image - çalışma mühiti (ASP.NET Core Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Build Image - layihəni tərtib etmək üçün (proje derleme)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Projeyi kopyalayın ve restore işlemi yapın
COPY ./Services.ApiGateway/Services.ApiGateway.csproj ./Services.ApiGateway/
RUN dotnet restore "Services.ApiGateway/Services.ApiGateway.csproj"

# Diğer dosyaları kopyalayın ve projeyi build edin
COPY . . 
WORKDIR "/src/Services.ApiGateway"
RUN dotnet build "./Services.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3. Publish Image - yayımlama mərhələsi
FROM build AS publish
RUN dotnet publish "./Services.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4. Final Image - tətbiqin son mərhələsi
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Uygulamayı başlatma
ENTRYPOINT ["dotnet", "Services.ApiGateway.dll"]

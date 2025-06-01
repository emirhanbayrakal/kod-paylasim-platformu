
# Temel ASP.NET Core çalışma zamanı imajı
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# SDK içeren imaj ile build işlemi
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "UserAuthApp.csproj"
RUN dotnet publish "UserAuthApp.csproj" -c Release -o /app/publish

# Yayına hazırlık
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "UserAuthApp.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NovaCode Web Services/NovaCode Web Services.csproj", "NovaCode Web Services/"]
RUN dotnet restore "NovaCode Web Services/NovaCode Web Services.csproj"
COPY . .
WORKDIR "/src/NovaCode Web Services"
RUN dotnet build "NovaCode Web Services.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NovaCode Web Services.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8000
ENTRYPOINT ["dotnet", "NovaCode Web Services.dll"]

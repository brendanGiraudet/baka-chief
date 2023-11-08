FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 3535

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./bakaChiefApplication.csproj"

RUN dotnet build "./bakaChiefApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./bakaChiefApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "/app/wwwroot/_framework/bakaChiefApplication.dll"]

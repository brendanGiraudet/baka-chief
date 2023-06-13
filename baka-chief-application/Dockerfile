FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 3535

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["./baka-chief-application.csproj", "baka-chief-application/"]
WORKDIR "/src/baka-chief-application"
RUN dotnet restore "./baka-chief-application.csproj"
COPY . .
RUN dotnet build "baka-chief-application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "baka-chief-application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "baka-chief-application.dll"]
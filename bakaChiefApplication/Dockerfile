﻿FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./bakaChiefApplication.csproj"

RUN dotnet build "./bakaChiefApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./bakaChiefApplication.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
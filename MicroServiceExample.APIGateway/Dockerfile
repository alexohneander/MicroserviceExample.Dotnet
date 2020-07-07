#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MicroServiceExample.APIGateway/MicroServiceExample.APIGateway.csproj", "MicroServiceExample.APIGateway/"]
RUN dotnet restore "MicroServiceExample.APIGateway/MicroServiceExample.APIGateway.csproj"
COPY . .
WORKDIR "/src/MicroServiceExample.APIGateway"
RUN dotnet build "MicroServiceExample.APIGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroServiceExample.APIGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroServiceExample.APIGateway.dll"]
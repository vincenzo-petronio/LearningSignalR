#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT="Development"
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RealTimeEvents.Client/RealTimeEvents.Client.csproj", "RealTimeEvents.Client/"]
RUN dotnet restore "RealTimeEvents.Client/RealTimeEvents.Client.csproj"
COPY . .
WORKDIR "/src/RealTimeEvents.Client"
RUN dotnet build "RealTimeEvents.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RealTimeEvents.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RealTimeEvents.Client.dll"]
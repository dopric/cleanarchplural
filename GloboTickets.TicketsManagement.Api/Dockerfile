FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GloboTickets.TicketsManagement.Api/GloboTickets.TicketsManagement.Api.csproj", "GloboTickets.TicketsManagement.Api/"]
RUN dotnet restore "GloboTickets.TicketsManagement.Api/GloboTickets.TicketsManagement.Api.csproj"
COPY . .
WORKDIR "/src/GloboTickets.TicketsManagement.Api"
RUN dotnet build "GloboTickets.TicketsManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GloboTickets.TicketsManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GloboTickets.TicketsManagement.Api.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Lookups/Lookups.csproj", "Lookups/"]
RUN dotnet restore "Lookups/Lookups.csproj"
COPY . .
WORKDIR "/src/Lookups"
RUN dotnet build "Lookups.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lookups.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lookups.dll"]
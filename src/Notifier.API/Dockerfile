#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Notifier.API/Notifier.API.csproj", "Notifier.API/"]
RUN dotnet restore "Notifier.API/Notifier.API.csproj"
COPY . .
WORKDIR "/src/Notifier.API"
RUN dotnet build "Notifier.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notifier.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notifier.API.dll"]
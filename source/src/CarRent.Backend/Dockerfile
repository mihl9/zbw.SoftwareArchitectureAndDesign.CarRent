#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["source/src/CarRent.Backend/CarRent.Backend.csproj", "source/src/CarRent.Backend/"]
COPY ["source/src/CarRent.Model/CarRent.Model.csproj", "source/src/CarRent.Model/"]
RUN dotnet restore "source/src/CarRent.Backend/CarRent.Backend.csproj"
COPY . .
WORKDIR "/src/source/src/CarRent.Backend"
RUN dotnet build "CarRent.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarRent.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarRent.Backend.dll"]
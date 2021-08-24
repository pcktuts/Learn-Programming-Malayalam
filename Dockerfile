#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Learn Programming Malayalam.csproj", ""]
RUN dotnet restore "./Learn Programming Malayalam.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Learn Programming Malayalam.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Learn Programming Malayalam.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Learn Programming Malayalam.dll"]
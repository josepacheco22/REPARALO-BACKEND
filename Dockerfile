#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080
EXPOSE 7032

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ApiRestREPARALO/ApiRestREPARALO.csproj", "ApiRestREPARALO/"]
COPY ["Data.REPARALO/Data.REPARALO.csproj", "Data.REPARALO/"]
RUN dotnet restore "ApiRestREPARALO/ApiRestREPARALO.csproj"
COPY . .
WORKDIR "/src/ApiRestREPARALO"
RUN dotnet build "ApiRestREPARALO.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiRestREPARALO.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiRestREPARALO.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Financas.Calculadoras.Juros.Api/Financas.Calculadoras.Juros.Api.csproj", "src/Financas.Calculadoras.Juros.Api/"]
COPY ["src/Financas.Calculadoras.Juros.Dtos/Financas.Calculadoras.Juros.Dtos.csproj", "src/Financas.Calculadoras.Juros.Dtos/"]
COPY ["src/Financas.Calculadoras.Juros.Queries/Financas.Calculadoras.Juros.Queries.csproj", "src/Financas.Calculadoras.Juros.Queries/"]
COPY ["src/Financas.Calculadoras.Juros.Clients/Financas.Calculadoras.Juros.Clients.csproj", "src/Financas.Calculadoras.Juros.Clients/"]
COPY ["src/Financas.Calculadoras.Juros.Domain/Financas.Calculadoras.Juros.Domain.csproj", "src/Financas.Calculadoras.Juros.Domain/"]
RUN dotnet restore "src/Financas.Calculadoras.Juros.Api/Financas.Calculadoras.Juros.Api.csproj"
COPY . .
WORKDIR "/src/src/Financas.Calculadoras.Juros.Api"
RUN dotnet build "Financas.Calculadoras.Juros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Financas.Calculadoras.Juros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Financas.Calculadoras.Juros.Api.dll"]

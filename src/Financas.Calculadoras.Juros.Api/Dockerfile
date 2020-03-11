#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Financas.Calculadoras.Juros.Api/Financas.Calculadoras.Juros.Api.csproj", "Financas.Calculadoras.Juros.Api/"]
RUN dotnet restore "Financas.Calculadoras.Juros.Api/Financas.Calculadoras.Juros.Api.csproj"
COPY . .
WORKDIR "/src/Financas.Calculadoras.Juros.Api"
RUN dotnet build "Financas.Calculadoras.Juros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Financas.Calculadoras.Juros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Financas.Calculadoras.Juros.Api.dll"]
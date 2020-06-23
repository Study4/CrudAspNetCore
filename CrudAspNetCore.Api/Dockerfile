#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#docker build -f CrudAspNetCore.Api\Dockerfile .

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY [".", "CrudAspNetCore.Api/"]
#RUN dotnet restore "CrudAspNetCore.Api/CrudAspNetCore.Api.csproj"
#COPY . .
WORKDIR "/src/CrudAspNetCore.Api"
RUN dotnet build "CrudAspNetCore.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CrudAspNetCore.Api.csproj" -c Release -o /app

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT=Production
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CrudAspNetCore.Api.dll"]
# CrudAspNetCore
CRUD - ASP.NET Core - 3.0 Preview 5

## 目標

- ASP.NET Core Web API CRUD Sample
    - Docker Support ( Dockerfile )
- DockerFile support dotnet build and build docker image
- Dcoker-Compose Support
    - Docker-Compose support Blazor Client ( need download blazor client docker image , is auto )
    - Dcoker-Compose support SQL Server Linux Container

## Issue

- Docker not use SSL

## How use
### dotnet
need LocalDB

dotnet build
dotnet run

go to https://localhost:5001/api/values
or
go to https://localhost:5001/api/employees ( need LocalDB )

### docker 
need install docker 

docker-compose build
docker-compose up

go to https://localhost:4000 ( It is Blazor UI)
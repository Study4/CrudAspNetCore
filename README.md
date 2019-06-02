# CrudAspNetCore
CRUD - ASP.NET Core 

## 目標

1. ASP.NET Core Web API CRUD Sample
    a. Docker Support ( Dockerfile )
3. DockerFile support dotnet build and build docker image
3. Dcoker-Compose Support
    a. Docker-Compose support Blazor Client ( need download blazor client docker image , is auto )
    b. Dcoker-Compose support SQL Server Linux Container

## Issue

1. Remove ASP.NET Core 2.1 HTTPS - SSL

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
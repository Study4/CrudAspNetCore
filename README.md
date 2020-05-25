# CrudAspNetCore
CRUD - ASP.NET Core - 3.1

## 目標

- ASP.NET Core Web API CRUD Sample
    - Docker Support ( Dockerfile )
    - Enable 單一檔案功能
- Support Swagger 
    - Swagger UI [https://localhost:5001/swagger/index.html](https://localhost:5001/swagger/index.html)
    - Swagger Json [https://localhost:5001/swagger/v1/swagger.json](https://localhost:5001/swagger/v1/swagger.json)
- DockerFile support dotnet build and build docker image
- Docker-Compose Support
    - Docker-Compose support Blazor Client ( need download blazor client docker image , is auto )
    - Docker-Compose support SQL Server Linux Container

## How use
### dotnet
#### Windows
need LocalDB

dotnet build
dotnet run

go to https://localhost:5001/api/test ( Show Hello World )
or
go to https://localhost:5001/api/employees ( need LocalDB )

#### Mac
need SQL Server for Linux

dotnet build
dotnet run --launch-profile Mac

go to https://localhost:5001/api/test ( Show Hello World )
or
go to https://localhost:5001/api/employees ( need SQL Server for Linux )

### docker ( for Mac / Windows / Linux )
- need install docker 
- Auto use SQL Server for Linux Container
- Auto use Blazor UI form Container

docker-compose build
docker-compose up

go to https://localhost:4000 ( It is Blazor UI)
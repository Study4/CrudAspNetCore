# CrudAspNetCore
CRUD - ASP.NET Core - 3.1

## 目標

Update : 2020-06-22

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
- [Tye](https://github.com/dotnet/tye) support

## 更新履歷

* 2020-06-22
  * 增加 [Tye](https://github.com/dotnet/tye) 支援
  * Cors Domain bug fix
* 前略

## How use - Full Stack

包含前端 ( Blazor ) 和後端 ( API ) 還有資料庫。

### docker ( for Mac / Windows / Linux )

- Need install docker 
- Use SQL Server for Linux Container ( Auto Download )
- Use Blazor UI form Container ( Auto Download )

```shell
docker-compose build
docker-compose up
```

go to https://localhost:4000 ( It is Blazor UI)

## How use - API Only

僅包含後端 ( API ) 和資料庫。

### Tye ( for Mac / Windows / Linux )

- Need install docker 
- Need install Tye
- Use SQL Server for Linux Container ( Auto Download )

```shell
tye run
```

go to https://localhost:4000 ( It is Blazor UI)

### Windows - Visual Studio 2019

- need LocalDB

載入專案後，選擇 IISExpress 模式啟動，此模式會採用 appsettings.DevelopmentForLocalDB.json 設定檔，ConnectionString 會使用 LocalDB。

### Windows - CMD or PowerShell

- need LocalDB

```shell
dotnet build
dotnet run --launch-profile DevelopmentForLocalDB
```

go to https://localhost:5001/api/test ( Show Hello World )
or
go to https://localhost:5001/api/employees ( need LocalDB )

### Container

- Need install docker
- Use SQL Server for Linux Container

```shell
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong@Passw0rd>" -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2017-latest
dotnet build
dotnet run
```

go to https://localhost:5001/api/test ( Show Hello World )
or
go to https://localhost:5001/api/employees ( Need SQL Server for Linux )
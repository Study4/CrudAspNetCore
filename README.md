# CrudAspNetCore

CRUD - ASP.NET Core - .NET 5

## 目標

Update : 2020-12-13

- ASP.NET Core Web API CRUD Sample
  - 包含 Docker Support ( Dockerfile )
  - Enable 單一檔案功能
  - Support Swagger 
      - Swagger UI [https://localhost:5001/swagger/index.html](https://localhost:5001/swagger/index.html)
      - Swagger Json [https://localhost:5001/swagger/v1/swagger.json](https://localhost:5001/swagger/v1/swagger.json)
- Use DockerFile to dotnet build and build docker image
- Use GitHub Action auto build to GitHub Package
- [Tye](https://github.com/dotnet/tye) support
- Docker-Compose Support

## 更新履歷

* 2020-12-13
  * 更新 .NET 5
  * 更新 Tye 的描述，增加 Blazor Wasm Front-end
* 2020-06-22
  * 增加 [Tye](https://github.com/dotnet/tye) 支援
  * Cors Domain bug fix
* 前略

## 環境參數

* Development ( default ) : DB 連線到 localhost
* DevelopmentForLocalDB : DB 連線到 localDB ( Windows 環境 )
* Tye : DB 連線到 sky-hr-db
* Production : DB 連線到 hr-mssql

## How use - Full Stack

包含前端 ( Blazor ) 和後端 ( API ) 還有 Database。

### Use Tye ( for Mac / Windows / Linux )

Required 
- Need install docker 
- Need install Tye
- Use SQL Server for Linux Container ( Auto Download )

Environment : Tye

```shell
tye run
```

go to https://localhost:4000 ( It is Blazor UI)

### Use docker ( for Mac / Windows / Linux )

Required 
- Need install docker 
- Use SQL Server for Linux Container ( Auto Download )
- Use Blazor UI form Container ( Auto Download )

Environment : Production

```shell
docker-compose build
docker-compose up
```

go to https://localhost:4000 ( It is Blazor UI)

## How use - API Only

僅包含後端 ( API ) 和資料庫。

單獨執行情況下，請修改成底下，改使用預設的 appsetting.json

### Windows - Visual Studio 2019

- need LocalDB

Environment : DevelopmentForLocalDB

載入專案後，選擇 IISExpress 模式啟動，此模式會採用 appsettings.DevelopmentForLocalDB.json 設定檔，ConnectionString 會使用 LocalDB。

### Windows - CMD or PowerShell

- need LocalDB

Environment : DevelopmentForLocalDB

```shell
dotnet build
dotnet run --launch-profile DevelopmentForLocalDB
```

go to https://localhost:5001/api/test ( Show Hello World )

go to https://localhost:5001/api/employees ( need LocalDB )

### Container

- Need install docker
- Use SQL Server for Linux Container

Environment : Development

```shell
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong@Passw0rd>" -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2019-latest
dotnet build
dotnet run
```

go to https://localhost:5001/api/test ( Show Hello World )

go to https://localhost:5001/api/employees ( Need SQL Server for Linux )
FROM microsoft/dotnet:2.1-aspnetcore-runtime
ARG source
ENV ASPNETCORE_ENVIRONMENT=DevTest
WORKDIR /app
EXPOSE 80
COPY ${source:-bin/Debug/netcoreapp2.1/Docker/publish} .
ENTRYPOINT ["dotnet", "CrudAspNetCore.Api.dll"]
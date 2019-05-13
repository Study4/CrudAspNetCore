FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-preview5-nanoserver-1809
ARG source
ENV ASPNETCORE_ENVIRONMENT=DevTest
WORKDIR /app
EXPOSE 80
COPY ${source:-bin/Debug/netcoreapp3.0/publish} .
ENTRYPOINT ["dotnet", "CrudAspNetCore.Api.dll"]
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./pcf-push-dotnet-core-mvvm-docker-windows/
RUN dotnet restore pcf-push-dotnet-core-mvvm-docker-windows/Pcf.Push.Dotnet.Core.Mvvm.Docker.Windows.csproj

# Copy everything else and build
COPY . ./pcf-push-dotnet-core-mvvm-docker-windows/
WORKDIR /app/pcf-push-dotnet-core-mvvm-docker-windows
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
COPY --from=build /app/pcf-push-dotnet-core-mvvm-docker-windows/out ./

EXPOSE 8080/tcp
ENV ASPNETCORE_URLS=http://*:8080 
ENTRYPOINT ["dotnet", "Pcf.Push.Dotnet.Core.Mvvm.Docker.Windows.dll", "--server-urls", "http://*:8080"]
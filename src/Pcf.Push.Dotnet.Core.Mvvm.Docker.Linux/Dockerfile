FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./pcf-push-dotnet-core-mvvm-docker-linux/
RUN dotnet restore pcf-push-dotnet-core-mvvm-docker-linux/Pcf.Push.Dotnet.Core.Mvvm.Docker.Linux.csproj

# Copy everything else and build
COPY . ./pcf-push-dotnet-core-mvvm-docker-linux/
WORKDIR /app/pcf-push-dotnet-core-mvvm-docker-linux
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine AS runtime
COPY --from=build /app/pcf-push-dotnet-core-mvvm-docker-linux/out ./

EXPOSE 8080/tcp
ENV ASPNETCORE_URLS=http://*:8080 
ENTRYPOINT ["dotnet", "Pcf.Push.Dotnet.Core.Mvvm.Docker.Linux.dll"]
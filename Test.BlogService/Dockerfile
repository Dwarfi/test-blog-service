#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Test.BlogService/Test.BlogService.API.csproj", "Test.BlogService/"]
COPY ["Test.BlogService.Application/Test.BlogService.Application.csproj", "Test.BlogService.Application/"]
COPY ["Test.BlogService.Domain/Test.BlogService.Domain.csproj", "Test.BlogService.Domain/"]
COPY ["Test.BlogService.Infrastructure/Test.BlogService.Infrastructure.csproj", "Test.BlogService.Infrastructure/"]
RUN dotnet restore "./Test.BlogService/./Test.BlogService.API.csproj"
COPY . .
WORKDIR "/src/Test.BlogService"
RUN dotnet build "./Test.BlogService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Test.BlogService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.BlogService.API.dll"]
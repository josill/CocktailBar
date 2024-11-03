FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY ["src/CocktailBar.Api/CocktailBar.Api.csproj", "src/CocktailBar.Api/"]
COPY ["src/CocktailBar.Contracts/CocktailBar.Contracts.csproj", "src/CocktailBar.Contracts/"]
COPY ["src/CocktailBar.Infrastructure/CocktailBar.Infrastructure.csproj", "src/CocktailBar.Infrastructure/"]
COPY ["src/CocktailBar.Application/CocktailBar.Application.csproj", "src/CocktailBar.Application/"]
COPY ["src/CocktailBar.Domain/CocktailBar.Domain.csproj", "src/CocktailBar.Domain/"]
# COPY ["src/CocktailBar.Tests/CocktailBar.Tests.csproj", "src/CocktailBar.Tests/"]

RUN dotnet restore "src/CocktailBar.Api/CocktailBar.Api.csproj"

COPY src/ ./src

RUN dotnet publish "src/CocktailBar.Api/CocktailBar.Api.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CocktailBar.Api.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Smakownia.Basket.Api/Smakownia.Basket.Api.csproj", "src/Smakownia.Basket.Api/"]
COPY ["src/Smakownia.Basket.Application/Smakownia.Basket.Application.csproj", "src/Smakownia.Basket.Application/"]
COPY ["src/Smakownia.Basket.Domain/Smakownia.Basket.Domain.csproj", "src/Smakownia.Basket.Domain/"]
COPY ["src/Smakownia.Basket.Infrastructure/Smakownia.Basket.Infrastructure.csproj", "src/Smakownia.Basket.Infrastructure/"]
RUN dotnet restore "src/Smakownia.Basket.Api/Smakownia.Basket.Api.csproj"
COPY . .
WORKDIR "/src/src/Smakownia.Basket.Api"
RUN dotnet build "Smakownia.Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Smakownia.Basket.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Smakownia.Basket.Api.dll"]

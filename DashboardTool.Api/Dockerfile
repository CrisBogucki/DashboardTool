FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DashboardTool.Api/DashboardTool.Api.csproj", "DashboardTool.Api/"]
RUN dotnet restore "DashboardTool.Api/DashboardTool.Api.csproj"
COPY . .
WORKDIR "/src/DashboardTool.Api"
RUN dotnet build "DashboardTool.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DashboardTool.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DashboardTool.Api.dll"]

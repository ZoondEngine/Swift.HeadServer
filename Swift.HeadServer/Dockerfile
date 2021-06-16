FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Swift.HeadServer/Swift.HeadServer.csproj", "Swift.HeadServer/"]
RUN dotnet restore "Swift.HeadServer/Swift.HeadServer.csproj"
COPY . .
WORKDIR "/src/Swift.HeadServer"
RUN dotnet build "Swift.HeadServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Swift.HeadServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Swift.HeadServer.dll"]

FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

ENV REDIS_CONNECTION_STRING=redis:6379

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src

ENV REDIS_CONNECTION_STRING=redis:6379

COPY EsiTest.RedisInMemory/EsiTest.RedisInMemory.csproj EsiTest.RedisInMemory/
RUN dotnet restore EsiTest.RedisInMemory/EsiTest.RedisInMemory.csproj
COPY . .
WORKDIR /src/EsiTest.RedisInMemory
RUN dotnet build EsiTest.RedisInMemory.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EsiTest.RedisInMemory.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV REDIS_CONNECTION_STRING=redis:6379
ENTRYPOINT ["dotnet", "EsiTest.RedisInMemory.dll"]

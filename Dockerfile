ARG PROJ_NAME="EpicFreeGames"
ARG PROJ_PATH="./EpicFreeGames/"

FROM hub.aiursoft.cn/mcr.microsoft.com/dotnet/sdk:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM hub.aiursoft.cn/mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG PROJ_NAME
ARG PROJ_PATH

WORKDIR /src
COPY "${PROJ_PATH}${PROJ_NAME}.csproj" "./${PROJ_NAME}/"
RUN dotnet restore ${PROJ_PATH}${PROJ_NAME}.csproj
COPY . .
WORKDIR "/src/${PROJ_NAME}"
RUN dotnet build "./${PROJ_NAME}.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./${PROJ_NAME}.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM hub.aiursoft.cn/mcr.microsoft.com/dotnet/aspnet:8.0 as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EpicFreeGames.dll", "--urls", "http://*:5000"]
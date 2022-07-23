FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TgBotFramework.Examples/BanhubBot/BanhubBot.csproj", "BanhubBot/"]
RUN dotnet restore "TgBotFramework.Examples/BanhubBot/BanhubBot.csproj"
COPY . .
WORKDIR "/src/BanhubBot"
RUN dotnet build "BanhubBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BanhubBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BanhubBot.dll"]

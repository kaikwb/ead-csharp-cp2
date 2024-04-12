FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ead-csharp-cp2/ead-csharp-cp2.csproj", "ead-csharp-cp2/"]
RUN dotnet restore "ead-csharp-cp2/ead-csharp-cp2.csproj"
COPY . .
WORKDIR "/src/ead-csharp-cp2"
RUN dotnet build "ead-csharp-cp2.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ead-csharp-cp2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ead-csharp-cp2.dll"]

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Redcode/Redcode.csproj", "Redcode/"]
RUN dotnet restore "Redcode/Redcode.csproj"

COPY . .
WORKDIR "/src/Redcode"

RUN dotnet publish "Redcode.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Redcode.dll"]
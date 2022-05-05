FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Movie_Library/Movie_Library.csproj", "Movie_Library/"]
RUN dotnet restore "Movie_Library/Movie_Library.csproj"
COPY . .
WORKDIR "/src/Movie_Library"
RUN dotnet build "Movie_Library.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Movie_Library.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Movie_Library.dll"]

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 49684
EXPOSE 44338

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WebScanner/WebScanner.csproj", "WebScanner/"]
RUN dotnet restore "WebScanner/WebScanner.csproj"
COPY . .
WORKDIR "/src/WebScanner"
RUN dotnet build "WebScanner.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebScanner.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebScanner.dll"]
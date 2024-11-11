FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
USER root

WORKDIR /src

COPY . .
RUN dotnet publish Taskeroni/Taskeroni.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app

COPY --from=build /app .

EXPOSE 5000

ENTRYPOINT ["dotnet", "Taskeroni.dll"]
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY . ./aspnetapp/
WORKDIR /app/aspnetapp
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime AS runtime
WORKDIR /app

COPY --from=build-env /app/aspnetapp/out/ ./
ENTRYPOINT ["dotnet", "RandomPersonPicker.Api.dll"]
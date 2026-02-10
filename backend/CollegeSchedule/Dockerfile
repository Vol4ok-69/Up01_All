FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY CollegeSchedule.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

EXPOSE 5268

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CollegeSchedule.dll"]

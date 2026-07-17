# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY AgeCalculator/AgeCalculator.csproj ./AgeCalculator/
RUN dotnet restore ./AgeCalculator/AgeCalculator.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish AgeCalculator/AgeCalculator.csproj -c Release -o out

# Stage 2: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose port 8080 (Render's default)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

ENTRYPOINT ["dotnet", "AgeCalculator.dll"]

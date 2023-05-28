# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./GreenBay-Backend/GreenBay-Backend.csproj" --disable-parallel
RUN dotnet publish "./GreenBay-Backend/GreenBay-Backend.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

# Please insert sensitive data
ENV ASPNETCORE_URLS=http://+:5000
ENV DefaultConnection=Server=happy_brown;Database=GreenBay;User=greenbay;Password=<insert_password_here>
ENV GreenBayToken=<insert_password_here>

EXPOSE 5000

ENTRYPOINT ["dotnet", "GreenBay-Backend.dll"]
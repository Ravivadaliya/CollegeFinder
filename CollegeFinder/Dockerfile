# Use the .NET SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /src

# Copy the .csproj file into the container
COPY ["path/to/CollegeFinder/CollegeFinder.csproj", "CollegeFinder/"]

# Restore dependencies
RUN dotnet restore "CollegeFinder/CollegeFinder.csproj"

# Copy the rest of the application code
COPY . .

# Build the application
RUN dotnet build "CollegeFinder/CollegeFinder.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "CollegeFinder/CollegeFinder.csproj" -c Release -o /app/publish

# Use the .NET runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollegeFinder.dll"]

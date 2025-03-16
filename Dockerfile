# Use the official .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution and project files 
COPY Snappymob.FileHandler.sln ./
COPY src/Snappymob.FileHandler.Common/Snappymob.FileHandler.Common.csproj src/Snappymob.FileHandler.Common/
COPY src/Snappymob.FileHandler.Service/Snappymob.FileHandler.Service.csproj src/Snappymob.FileHandler.Service/
COPY src/Snappymob.FileHandler.FileCreator/Snappymob.FileHandler.FileCreator.csproj src/Snappymob.FileHandler.FileCreator/
COPY src/Snappymob.FileHandler.FileProcessor/Snappymob.FileHandler.FileProcessor.csproj src/Snappymob.FileHandler.FileProcessor/

COPY tests/SnappyMob.FileHandler.Common.Test/SnappyMob.FileHandler.Common.Test.csproj tests/SnappyMob.FileHandler.Common.Test/
COPY tests/Snappymob.FileHandler.Service.Test/Snappymob.FileHandler.Service.Test.csproj tests/Snappymob.FileHandler.Service.Test/
COPY tests/Snappymob.FileHandler.FileCreator.Test/Snappymob.FileHandler.FileCreator.Test.csproj tests/Snappymob.FileHandler.FileCreator.Test/
COPY tests/Snappymob.FileHandler.FileProcessor.Test/Snappymob.FileHandler.FileProcessor.Test.csproj tests/Snappymob.FileHandler.FileProcessor.Test/

# Restore dependencies
RUN dotnet restore

# Copy the entire source code and build both console applications
COPY . .
RUN dotnet publish src/Snappymob.FileHandler.FileCreator/Snappymob.FileHandler.FileCreator.csproj -c Release -o /app/out/FileCreator
RUN dotnet publish src/Snappymob.FileHandler.FileProcessor/Snappymob.FileHandler.FileProcessor.csproj -c Release -o /app/out/FileProcessor

# Use the official .NET runtime image to run the applications
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Create output directory
RUN mkdir -p /app/output

# Create output directory and copy both published applications
COPY --from=build /app/out/FileCreator ./FileCreator
COPY --from=build /app/out/FileProcessor ./FileProcessor

# Run FileCreator first and then FileProcessor
ENTRYPOINT ["sh", "-c", "dotnet FileCreator/Snappymob.FileHandler.FileCreator.dll && dotnet FileProcessor/Snappymob.FileHandler.FileProcessor.dll  && mv *.txt /app/output || true"]

# Define a volume
VOLUME /app/output

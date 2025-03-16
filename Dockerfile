# Stage 1: Build the Common library
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-common
WORKDIR /src/Snappymob.FileHandler.Common
COPY src/Snappymob.FileHandler.Common/Snappymob.FileHandler.Common.csproj .
RUN dotnet restore
COPY src/Snappymob.FileHandler.Common/ .
RUN dotnet publish -c Release -o /app/common

# Stage 2: Build the Service library
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-service
WORKDIR /src/Snappymob.FileHandler.Service
COPY src/Snappymob.FileHandler.Service/Snappymob.FileHandler.Service.csproj .
RUN dotnet restore
COPY src/Snappymob.FileHandler.Service/ .
COPY --from=build-common /app/common .
RUN dotnet publish -c Release -o /app/service

# Stage 3: Build the FileCreator console app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-filecreator
WORKDIR /src/Snappymob.FileHandler.FileCreator
COPY src/Snappymob.FileHandler.FileCreator/Snappymob.FileHandler.FileCreator.csproj .
RUN dotnet restore
COPY src/Snappymob.FileHandler.FileCreator/ .
COPY --from=build-service /app/service .
RUN dotnet publish -c Release -o /app/filecreator

# Stage 4: Build the FileProcessor console app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-fileprocessor
WORKDIR /src/Snappymob.FileHandler.FileProcessor
COPY src/Snappymob.FileHandler.FileProcessor/Snappymob.FileHandler.FileProcessor.csproj .
RUN dotnet restore
COPY src/Snappymob.FileHandler.FileProcessor/ .
COPY --from=build-service /app/service .
RUN dotnet publish -c Release -o /app/fileprocessor


# Create the output directory for the file creator and processor
RUN mkdir -p /app/output

# Stage 5: Runtime for FileCreator
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime-filecreator
WORKDIR /app
COPY --from=build-filecreator /app/filecreator .
ENTRYPOINT ["./Snappymob.FileHandler.FileCreator.dll"]

# Stage 6: Runtime for FileProcessor
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime-fileprocessor
WORKDIR /app
COPY --from=build-fileprocessor /app/fileprocessor .
ENTRYPOINT ["./Snappymob.FileHandler.FileProcessor.dll"]

# Define a volume
VOLUME /app/output
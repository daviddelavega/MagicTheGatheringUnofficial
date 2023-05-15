# Set the base image to use
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the project files to the container and the yml files for the MagicTheGathering Card data
COPY ./*.csproj ./
COPY ./*.yml ./
COPY libraries.yml /app/
RUN dotnet restore

# Copy the application code to the container
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Set the base image for the final runtime
FROM mcr.microsoft.com/dotnet/runtime:6.0

# Set the working directory in the container
WORKDIR /app

# Copy the built application from the previous stage
COPY --from=build /app/out .

COPY . /app

# Set the entry point for the container
CMD ["dotnet", "MagicTheGatheringUnofficial.dll"]

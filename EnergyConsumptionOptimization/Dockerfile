# # Use the official Microsoft .NET Core SDK image as the base image
# FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# # Set the working directory
# WORKDIR /EnergyConsumptionOptimization

# # Copy the .csproj file and restore the NuGet packages
# COPY *.csproj ./
# RUN dotnet restore

# # Copy the rest of the application source code
# COPY . ./

# # Build the application in Release mode
# RUN dotnet publish -c Release -o out

# # Use the official Microsoft .NET Core Runtime image as the runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:7.0

# # Set the working directory
# WORKDIR /EnergyConsumptionOptimization

# # Copy the build output from the build image
# COPY --from=build /EnergyConsumptionOptimization/out ./

# # Expose the default ASP.NET Core port
# EXPOSE 5069


# # Run the application
# ENTRYPOINT ["dotnet", "EnergyConsumptionOptimization.dll", "--urls", "http://*:5069"]



# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /EnergyConsumptionOptimization
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /EnergyConsumptionOptimization
COPY --from=build /EnergyConsumptionOptimization/out ./
EXPOSE 5069
ENTRYPOINT ["dotnet", "EnergyConsumptionOptimization.dll"]

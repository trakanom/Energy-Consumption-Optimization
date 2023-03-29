# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /EnergyConsumptionOptimization
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /EnergyConsumptionOptimization
COPY --from=build /EnergyConsumptionOptimization/out ./
EXPOSE 5069

# Set ASPNETCORE_ENVIRONMENT to Development by default
ARG ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_ENVIRONMENT $ASPNETCORE_ENVIRONMENT

# Set the command to run the application, default to "run"
ARG COMMAND=run
ENV COMMAND $COMMAND

# Run the application
ENTRYPOINT ["sh", "-c", "dotnet ${COMMAND} EnergyConsumptionOptimization.dll"]

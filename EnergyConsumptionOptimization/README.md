# Energy Consumption Optimization Backend

This backend API is designed to help optimize energy consumption by tracking energy usage and providing recommendations for reducing energy consumption. The backend is built using ASP.NET Core Web API, C#, and Entity Framework Core.

## Project Structure

- `Controllers/DevicesController.cs`: Contains the API endpoints for managing devices.
- `Controllers/EnergyUsageController.cs`: Contains the API endpoints for managing energy usage data and getting recommendations.
- `Data/ApplicationDbContext.cs`: Defines the database context for the application, which is used to interact with the database.
- `Models/Device.cs`: Defines the Device model, which represents an energy-consuming device.
- `Models/EnergyUsage.cs`: Defines the EnergyUsage model, which represents the energy usage data for a device.
- `Models/Recommendations.cs`: Defines the Recommendations model, which represents the recommendations for optimizing energy consumption.
- `Services/OptimizationService.cs`: Contains the business logic for energy consumption optimization, including data retrieval, recommendations generation, and data manipulation.
- `Startup.cs`: Configures the application's services and middleware.
- `appsettings.json`: Contains the application settings, including the database connection string.

## Getting Started

1. Clone the repository.
2. Open the project in Visual Studio or Visual Studio Code.
3. Run the application using the `dotnet run` command or by pressing F5 in Visual Studio/Visual Studio Code.
4. Use a tool like Postman to test the API endpoints.

## Deployment

Follow the official Microsoft documentation to deploy your ASP.NET Core Web API to Azure using Visual Studio or Visual Studio Code.


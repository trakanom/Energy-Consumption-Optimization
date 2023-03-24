using System.Collections.Generic;
using System.Linq;
using EnergyConsumptionOptimization.Models;
using EnergyConsumptionOptimization.Data;

namespace EnergyConsumptionOptimization.Services
{
    public class OptimizationService
    {
        // Declare a private readonly variable to hold the instance of ApplicationDbContext
        private readonly ApplicationDbContext _context;

        // Inject the ApplicationDbContext instance through the constructor
        public OptimizationService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implement the methods for handling devices

        public List<Device> GetAllDevices()
        {
            // Fetch all devices from the database and return as a list
            return _context.Devices.ToList();
        }

        public void AddDevice(Device device)
        {
            // Add the new device to the database
            _context.Devices.Add(device);
            // Save the changes to the database
            _context.SaveChanges();
        }

        public bool UpdateDevice(int id, Device updatedDevice)
        {
            // Find the device in the database by its ID
            var device = _context.Devices.Find(id);

            if (device == null)
            {
                // If the device is not found, return false
                return false;
            }

            // Update the device's properties with the new values
            device.Name = updatedDevice.Name;
            device.Type = updatedDevice.Type;
            device.PowerConsumption = updatedDevice.PowerConsumption;

            // Save the changes to the database
            _context.SaveChanges();

            // Return true if the update was successful
            return true;
        }

        public bool DeleteDevice(int id)
        {
            // Find the device in the database by its ID
            var device = _context.Devices.Find(id);

            if (device == null)
            {
                // If the device is not found, return false
                return false;
            }

            // Remove the device from the database
            _context.Devices.Remove(device);
            // Save the changes to the database
            _context.SaveChanges();

            // Return true if the deletion was successful
            return true;
        }

        // Implement the methods for handling energy usage

        public List<EnergyUsage> GetAllEnergyUsage()
        {
            // Fetch all energy usages from the database and return as a list
            return _context.EnergyUsages.ToList();
        }

        public void AddEnergyUsage(EnergyUsage energyUsage)
        {
            // Add the new energy usage to the database
            _context.EnergyUsages.Add(energyUsage);
            // Save the changes to the database
            _context.SaveChanges();
        }

        // Implement your energy consumption optimization logic in this method
        public List<Recommendations> GetRecommendations()
        {
            // Your optimization logic here
            // Return a list of recommendations based on the energy usage data and devices
            // For example:
            // 1. Analyze the energy usage patterns
            // 2. Find inefficient devices or usage times
            // 3. Suggest replacing devices or adjusting usage times to optimize energy consumption

            List<Recommendations> recommendations = new List<Recommendations>();
            // Add recommendations based on your logic
            // ...

            return recommendations;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyConsumptionOptimization.Models;
using EnergyConsumptionOptimization.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Device>> GetAllDevicesAsync()
        {
            // Fetch all devices from the database and return as a list
            return await _context.Devices.ToListAsync();
        }

        public async Task AddDevice(Device device)
        {
            // Add the new device to the database
            await _context.Devices.AddAsync(device);
            // Save the changes to the database
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateDeviceAsync(int id, Device updatedDevice)
        {
            // Find the device in the database by its ID
            var device = await _context.Devices.FindAsync(id);

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
            await _context.SaveChangesAsync();

            // Return true if the update was successful
            return true;
        }

        public async Task<bool> DeleteDeviceAsync(int id)
        {
            // Find the device in the database by its ID
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                // If the device is not found, return false
                return false;
            }

            // Remove the device from the database
            _context.Devices.Remove(device);
            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return true if the deletion was successful
            return true;
        }

        // Implement the methods for handling energy usage

        public async Task<List<EnergyUsage>> GetAllEnergyUsageAsync()
        {
            // Fetch all energy usages from the database and return as a list
            return await _context.EnergyUsages.ToListAsync();
        }

        public async Task AddEnergyUsageAsync(EnergyUsage energyUsage)
        {
            // Add the new energy usage to the database
            await _context.EnergyUsages.AddAsync(energyUsage);
            // Save the changes to the database
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteEnergyUsageAsync(int id)
        {
            // Find the energyUsage in the database by its ID
            var energyUsage = await _context.EnergyUsages.FindAsync(id);

            if (energyUsage == null)
            {
                // If the energyUsage is not found, return false
                return false;
            }

            // Remove the energyUsage from the database
            _context.EnergyUsages.Remove(energyUsage);
            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return true if the deletion was successful
            return true;
        }

        // Implement your energy consumption optimization logic in this method
        public Task<List<Recommendation>> GetRecommendationAsync()
        {
            // Your optimization logic here
            // ...

            List<Recommendation> recommendations = new();
            // Add recommendations based on your logic
            // ...

            return Task.FromResult(recommendations);
        }

    }
}

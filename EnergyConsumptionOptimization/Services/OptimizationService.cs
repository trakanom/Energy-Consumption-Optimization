using System.Collections.Generic;
using System.Linq;
using EnergyConsumptionOptimization.Models;
using EnergyConsumptionOptimization.Data;

namespace EnergyConsumptionOptimization.Services
{
    public class OptimizationService
    {
        private readonly ApplicationDbContext _context;

        public OptimizationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<EnergyUsage> GetAllEnergyUsages()
        {
            return _context.EnergyUsages.ToList();
        }

        public void AddEnergyUsage(EnergyUsage energyUsage)
        {
            _context.EnergyUsages.Add(energyUsage);
            _context.SaveChanges();
        }

        public List<Device> GetAllDevices()
        {
            return _context.Devices.ToList();
        }

        public void AddDevice(Device device)
        {
            _context.Devices.Add(device);
            _context.SaveChanges();
        }

        // Add other CRUD methods for updating and deleting EnergyUsage and Device entities

        // Add optimization logic related to energy consumption here
    }
}

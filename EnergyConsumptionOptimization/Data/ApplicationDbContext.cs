using Microsoft.EntityFrameworkCore;
using EnergyConsumptionOptimization.Models;

namespace EnergyConsumptionOptimization.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EnergyUsage> EnergyUsages { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}

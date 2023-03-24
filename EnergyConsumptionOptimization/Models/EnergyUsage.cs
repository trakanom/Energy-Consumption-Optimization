using System;
using System.ComponentModel.DataAnnotations;

namespace EnergyConsumptionOptimization.Models
{
    public class EnergyUsage
    {
        // Unique identifier for the energy usage entry
        [Key]
        public int Id { get; set; }

        // Date and time when the energy usage was recorded
        [Required]
        public DateTime Timestamp { get; set; }

        // Reference to the related device
        [Required]
        public Device Device { get; set; }

        // Duration of the energy usage in hours
        [Required]
        public double Duration { get; set; }

        // Additional properties can be added as needed
        // (e.g., location, user ID, etc.)
    }
}

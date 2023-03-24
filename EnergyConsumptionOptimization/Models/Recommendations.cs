using System.ComponentModel.DataAnnotations;

namespace EnergyConsumptionOptimization.Models
{
    public class Recommendation
    {
        // Unique identifier for the recommendation
        [Key]
        public int Id { get; set; }

        // Reference to the related device
        public Device? Device { get; set; }

        // Description of the recommended action (e.g., "Replace with an energy-efficient model", "Adjust usage time")
        public string? Action { get; set; }

        // Estimated savings per month in kilowatt-hours (kWh) as a result of the recommended action
        public double? Savings { get; set; }

        // Additional properties can be added as needed
        // (e.g., priority level, estimated cost of the action, etc.)
    }
}

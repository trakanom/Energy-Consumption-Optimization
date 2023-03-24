using System.ComponentModel.DataAnnotations;

namespace EnergyConsumptionOptimization.Models
{
    public class Device
    {
        // Unique identifier for the device
        [Key]
        public int Id { get; set; }

        // Name of the device (e.g., "Air Conditioner")
        [Required]
        public string Name { get; set; }

        // Type of the device (e.g., "HVAC", "Lighting", "Electronics")
        [Required]
        public string Type { get; set; }

        // Power consumption of the device in watts
        [Required]
        public double PowerConsumption { get; set; }

        // Constructor
        public Device()
        {
            Name = string.Empty;
            Type = string.Empty;
        }

        // Additional properties can be added as needed
        // (e.g., manufacturer, model number, installation date, etc.)
    }
}

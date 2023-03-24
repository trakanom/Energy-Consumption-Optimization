using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EnergyConsumptionOptimization.Models;
using EnergyConsumptionOptimization.Services;

namespace EnergyConsumptionOptimization.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        // Declare a private readonly variable to hold the instance of OptimizationService
        private readonly OptimizationService _optimizationService;

        // Inject the OptimizationService instance through the constructor
        public DevicesController(OptimizationService optimizationService)
        {
            _optimizationService = optimizationService;
        }

        // Define a GET action method to fetch all devices
        [HttpGet]
        public ActionResult<List<Device>> GetAllDevices()
        {
            // Call the GetAllDevices method from the OptimizationService
            // Return the result as an ActionResult with the fetched list of devices
            return _optimizationService.GetAllDevices();
        }

        // Define a POST action method to add a new device
        [HttpPost]
        public ActionResult AddDevice([FromBody] Device device)
        {
            // Check if the provided device data is valid
            if (ModelState.IsValid)
            {
                // Call the AddDevice method from the OptimizationService to add the new device
                _optimizationService.AddDevice(device);
                // Return a 200 OK status if the operation is successful
                return Ok();
            }
            // Return a 400 Bad Request status if the provided data is not valid
            return BadRequest(ModelState);
        }

        // Define a PUT action method to update an existing device by its ID
        [HttpPut("{id}")]
        public ActionResult UpdateDevice(int id, [FromBody] Device device)
        {
            // Check if the provided device data is valid
            if (ModelState.IsValid)
            {
                // Call the UpdateDevice method from the OptimizationService
                // Pass the ID of the device to be updated and the updated device data
                var result = _optimizationService.UpdateDevice(id, device);

                // Check if the device was found and updated successfully
                if ((bool)result)
                {
                    // Return a 200 OK status if the operation is successful
                    return Ok();
                }
            }
            // Return a 400 Bad Request status if the provided data is not valid
            return BadRequest(ModelState);
        }

        // Define a DELETE action method to delete a device by its ID
        [HttpDelete("{id}")]
        public ActionResult DeleteDevice(int id)
        {
            // Call the DeleteDevice method from the OptimizationService
            // Pass the ID of the device to be deleted
            var result = _optimizationService.DeleteDevice(id);

            // Check if the device was found and deleted successfully
            if ((bool)result)
            {
                // Return a 200 OK status if the operation is successful
                return Ok();
            }
            // Return a 404 Not Found status if the device is not found
            return NotFound();
        }
    }
}

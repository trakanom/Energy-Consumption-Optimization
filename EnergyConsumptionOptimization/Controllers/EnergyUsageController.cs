using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EnergyConsumptionOptimization.Models;
using EnergyConsumptionOptimization.Services;

namespace EnergyConsumptionOptimization.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnergyUsageController : ControllerBase
    {
        // Declare a private readonly variable to hold the instance of OptimizationService
        private readonly OptimizationService _optimizationService;

        // Inject the OptimizationService instance through the constructor
        public EnergyUsageController(OptimizationService optimizationService)
        {
            _optimizationService = optimizationService;
        }

        // Define a GET action method to fetch all energy usages
        [HttpGet]
        public ActionResult<List<EnergyUsage>> GetAllEnergyUsage()
        {
            // Call the GetAllEnergyUsages method from the OptimizationService
            // Return the result as an ActionResult with the fetched list of energy usages
            return _optimizationService.GetAllEnergyUsage();
        }

        // Define a POST action method to add a new energy usage
        [HttpPost]
        public ActionResult AddEnergyUsage([FromBody] EnergyUsage energyUsage)
        {
            // Check if the provided energy usage data is valid
            if (ModelState.IsValid)
            {
                // Call the AddEnergyUsage method from the OptimizationService to add the new energy usage
                _optimizationService.AddEnergyUsage(energyUsage);
                // Return a 200 OK status if the operation is successful
                return Ok();
            }
            // Return a 400 Bad Request status if the provided data is not valid
            return BadRequest(ModelState);
        }

        // Define a DELETE action method to delete an energy usage by its ID
        [HttpDelete("{id}")]
        public ActionResult DeleteEnergyUsage(int id)
        {
            // Call the DeleteEnergyUsage method from the OptimizationService
            // Pass the ID of the energy usage to be deleted
            var result = _optimizationService.DeleteEnergyUsage(id);

            // Check if the energy usage was found and deleted successfully
            if ((bool)result)
            {
                // Return a 200 OK status if the operation is successful
                return Ok();
            }
            // Return a 404 Not Found status if the energy usage is not found
            return NotFound();
        }

        // Define a GET action method to fetch recommendations for energy usage optimization
        [HttpGet("recommendations")]
        public async Task<ActionResult<List<Recommendations>>> GetRecommendations()
        {
            // Call the GetRecommendations method from the OptimizationService
            // Return the result as an ActionResult with the fetched list of optimized energy usages
            return _optimizationService.GetRecommendations();
        }
    }
}

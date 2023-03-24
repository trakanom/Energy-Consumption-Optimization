using Microsoft.EntityFrameworkCore;
using EnergyConsumptionOptimization.Data;

// ...

public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
}

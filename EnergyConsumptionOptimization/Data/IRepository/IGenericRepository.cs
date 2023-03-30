using EnergyConsumptionOptimization.Data;
using EnergyConsumptionOptimization.Models;
using EnergyConsumptionOptimization.Services;
namespace EnergyConsumptionOptimization.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        Task SaveAsync();
    }

}
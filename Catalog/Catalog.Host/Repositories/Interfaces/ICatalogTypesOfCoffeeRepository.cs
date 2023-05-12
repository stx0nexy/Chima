using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogTypesOfCoffeeRepository
{
    Task<int?> CreateAsync(string title, string description,bool available, string pictureFileName);
    
    Task<bool?> DeleteAsync(int id);
    
    Task<CatalogTypesOfCoffeeEntity?> UpdateAsync(CatalogTypesOfCoffeeEntity catalogTypesOfCoffee);
    
    Task<CatalogTypesOfCoffeeEntity?> GetByIdAsync(int id);
}
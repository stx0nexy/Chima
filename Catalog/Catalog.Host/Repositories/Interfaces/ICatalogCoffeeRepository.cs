using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogCoffeeRepository
{
    Task<int?> CreateAsync(string title, decimal price, string subTitle, string description, string pictureFileName, int catalogCategoryId, List<CatalogTypesOfCoffeeEntity> catalogTypesOfCoffee);
    
    Task<bool?> DeleteAsync(int id);
    
    Task<CatalogCoffeeEntity?> UpdateAsync(CatalogCoffeeEntity catalogCoffee);
    
    Task<CatalogCoffeeEntity?> GetByIdAsync(int id);
}
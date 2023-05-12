using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogCategoryRepository
{
    Task<int?> CreateAsync(string title);
    
    Task<bool?> DeleteAsync(int id);
    
    Task<CatalogCategoryEntity?> UpdateAsync(CatalogCategoryEntity catalogCategory);
    
    Task<CatalogCategoryEntity?> GetByIdAsync(int id);
}
using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogOtherPositionsRepository
{
    Task<int?> CreateAsync(string title, decimal price, string subTitle, string description,bool available, string pictureFileName, int catalogCategoryId);
    
    Task<bool?> DeleteAsync(int id);
    
    Task<CatalogOtherPositionsEntity?> UpdateAsync(CatalogOtherPositionsEntity catalogOtherPosition);
    
    Task<CatalogOtherPositionsEntity?> GetByIdAsync(int id);
}
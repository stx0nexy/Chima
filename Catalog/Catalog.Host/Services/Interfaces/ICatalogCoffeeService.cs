using Catalog.Host.Data.Entity;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogCoffeeService
{
    Task<int?> Create(string title, decimal price, string subTitle, string description, string pictureFileName, int catalogCategoryId, List<CatalogTypesOfCoffeeEntity> catalogTypesOfCoffee);    
    
    Task<bool?> Delete(int id);
    
    Task<CatalogCoffeeDto> Update(int id, string title, decimal price, string subTitle, string description, string pictureFileName, int catalogCategoryId, List<CatalogTypesOfCoffeeEntity> catalogTypesOfCoffee);
}
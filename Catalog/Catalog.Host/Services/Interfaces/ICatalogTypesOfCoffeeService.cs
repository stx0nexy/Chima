using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogTypesOfCoffeeService
{
    Task<int?> Create(string title, string description,bool available, string pictureFileName);
    
    Task<bool?> Delete(int id);
    
    Task<CatalogTypesOfCoffeeDto> Update(int id, string title, string description,bool available, string pictureFileName);
}
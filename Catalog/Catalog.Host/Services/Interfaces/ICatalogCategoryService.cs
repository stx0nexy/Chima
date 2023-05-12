using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogCategoryService
{
    Task<int?> Create(string title);
    
    Task<bool?> Delete(int id);
    
    Task<CatalogCategoryDto> Update(int id, string title);
}
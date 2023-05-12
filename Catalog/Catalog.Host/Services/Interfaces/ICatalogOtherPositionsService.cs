using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogOtherPositionsService
{
    Task<int?> Create(string title, decimal price, string subTitle, string description,bool available, string pictureFileName, int catalogCategoryId);
    
    Task<bool?> Delete(int id);
    
    Task<CatalogOtherPositionsDto> Update(int id, string title, decimal price, string subTitle, string description, string pictureFileName, int catalogCategoryId);
}
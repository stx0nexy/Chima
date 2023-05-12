using Catalog.Host.Data.Entity;
using Catalog.Host.Models;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogRepository
{
    Task<PaginatedItems<CatalogCoffeeEntity>> GetCoffeeByPageAsync(int pageIndex, int pageSize, int? categoryFilter);
    
    Task<PaginatedItems<CatalogCoffeeEntity>> GetCoffeeByCoffeeTypeAsync(string coffeeType, int pageIndex, int pageSize, int? categoryFilter);
    
    Task<PaginatedItems<CatalogCoffeeEntity>> SortCoffeeByAscendingPriceAsync(int pageIndex, int pageSize, int? categoryFilter);

    Task<PaginatedItems<CatalogCoffeeEntity>> SortCoffeeByDescendingPriceAsync(int pageIndex, int pageSize, int? categoryFilter);
    
    Task<PaginatedItems<CatalogOtherPositionsEntity>> GetOtherPositionsByPageAsync(int pageIndex, int pageSize, int? categoryFilter);
    
    Task<PaginatedItems<CatalogOtherPositionsEntity>> SortOtherPositionsByAscendingPriceAsync(int pageIndex, int pageSize, int? categoryFilter);

    Task<PaginatedItems<CatalogOtherPositionsEntity>> SortOtherPositionsByDescendingPriceAsync(int pageIndex, int pageSize, int? categoryFilter);
    
    Task<PaginatedItems<CatalogCategoryEntity>> GetCategoriesAsync();
    
    Task<PaginatedItems<CatalogTypesOfCoffeeEntity>> GetTypesOfCoffeeAsync();
}
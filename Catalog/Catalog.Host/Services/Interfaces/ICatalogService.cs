using Catalog.Host.Models;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogCoffeeDto>?> GetCoffeeByPage(int pageIndex, int pageSize, int? categoryFilter);
    
    Task<PaginatedItemsResponse<CatalogCoffeeDto>?> GetCoffeeByCoffeeType(string coffeeType, int pageIndex, int pageSize, int? categoryFilter);
    
    Task<PaginatedItemsResponse<CatalogCoffeeDto>?> SortCoffeeByAscendingPrice(int pageIndex, int pageSize, int? categoryFilter);

    Task<PaginatedItemsResponse<CatalogCoffeeDto>?> SortCoffeeByDescendingPrice(int pageIndex, int pageSize, int? categoryFilter);
    
    Task<PaginatedItemsResponse<CatalogOtherPositionsDto>?> GetOtherPositionsByPage(int pageIndex, int pageSize, int? categoryFilter);
    
    Task<PaginatedItemsResponse<CatalogOtherPositionsDto>?> SortOtherPositionsByAscendingPrice(int pageIndex, int pageSize, int? categoryFilter);

    Task<PaginatedItemsResponse<CatalogOtherPositionsDto>?> SortOtherPositionsByDescendingPrice(int pageIndex, int pageSize, int? categoryFilter);
    
    Task<ItemsResponse<CatalogCategoryDto>?> GetCategories();
    
    Task<ItemsResponse<CatalogTypesOfCoffeeDto>?> GetTypesOfCoffee();
}
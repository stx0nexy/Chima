using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService: BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogRepository _catalogRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogRepository catalogRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogRepository = catalogRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItemsResponse<CatalogCoffeeDto>?> GetCoffeeByPage(int pageIndex, int pageSize,
        int? categoryFilter)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogRepository.GetCoffeeByPageAsync(pageIndex, pageSize, categoryFilter);
            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogCoffeeDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogCoffeeDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogCoffeeDto>?> GetCoffeeByCoffeeType(string coffeeType, int pageIndex,
        int pageSize, int? categoryFilter)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogRepository.GetCoffeeByCoffeeTypeAsync(coffeeType, pageIndex, pageSize, categoryFilter);
            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogCoffeeDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogCoffeeDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogCoffeeDto>?> SortCoffeeByAscendingPrice(int pageIndex, int pageSize,
        int? categoryFilter)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogRepository.SortCoffeeByAscendingPriceAsync(pageIndex, pageSize, categoryFilter);
            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogCoffeeDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogCoffeeDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogCoffeeDto>?> SortCoffeeByDescendingPrice(int pageIndex,
        int pageSize, int? categoryFilter)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogRepository.SortCoffeeByDescendingPriceAsync(pageIndex, pageSize, categoryFilter);
            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogCoffeeDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogCoffeeDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogOtherPositionsDto>?> GetOtherPositionsByPage(int pageIndex,
        int pageSize, int? categoryFilter)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogRepository.GetOtherPositionsByPageAsync(pageIndex, pageSize, categoryFilter);
            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogOtherPositionsDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogOtherPositionsDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogOtherPositionsDto>?> SortOtherPositionsByAscendingPrice(
        int pageIndex, int pageSize, int? categoryFilter)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogRepository.SortOtherPositionsByAscendingPriceAsync(pageIndex, pageSize, categoryFilter);
            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogOtherPositionsDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogOtherPositionsDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogOtherPositionsDto>?> SortOtherPositionsByDescendingPrice(
        int pageIndex, int pageSize, int? categoryFilter)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogRepository.SortOtherPositionsByDescendingPriceAsync(pageIndex, pageSize, categoryFilter);
            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogOtherPositionsDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogOtherPositionsDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<ItemsResponse<CatalogCategoryDto>?> GetCategories()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogRepository.GetCategoriesAsync();
            return new ItemsResponse<CatalogCategoryDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogCategoryDto>(s)).ToList(),
            };
        });
    }

    public async Task<ItemsResponse<CatalogTypesOfCoffeeDto>?> GetTypesOfCoffee()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogRepository.GetTypesOfCoffeeAsync();
            return new ItemsResponse<CatalogTypesOfCoffeeDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogTypesOfCoffeeDto>(s)).ToList(),
            };
        });
    }
}
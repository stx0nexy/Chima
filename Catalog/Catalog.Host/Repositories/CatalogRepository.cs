using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogRepository> _logger;

    public CatalogRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogCoffeeEntity>> GetCoffeeByPageAsync(int pageIndex, int pageSize,
        int? categoryFilter)
    {
        IQueryable<CatalogCoffeeEntity> query = _dbContext.CatalogCoffee;

        if (categoryFilter.HasValue)
        {
            query = query.Where(w => w.CatalogCategoryId == categoryFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query
            .Include(i => i.CatalogCategory)
            .Include(i => i.CatalogTypesOfCoffee)
            .OrderBy(c => c.Title)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogCoffeeEntity>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogCoffeeEntity>> GetCoffeeByCoffeeTypeAsync(string coffeeType, int pageIndex,
        int pageSize, int? categoryFilter)
    {
        IQueryable<CatalogCoffeeEntity> query = _dbContext.CatalogCoffee;

        if (categoryFilter.HasValue)
        {
            query = query.Where(w => w.CatalogCategoryId == categoryFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query
            .Include(i => i.CatalogCategory)
            .Include(i => i.CatalogTypesOfCoffee.Equals(coffeeType))
            .OrderBy(c => c.Title)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogCoffeeEntity>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogCoffeeEntity>> SortCoffeeByAscendingPriceAsync(int pageIndex, int pageSize,
        int? categoryFilter)
    {
        IQueryable<CatalogCoffeeEntity> query = _dbContext.CatalogCoffee;

        if (categoryFilter.HasValue)
        {
            query = query.Where(w => w.CatalogCategoryId == categoryFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query
            .Include(i => i.CatalogCategory)
            .Include(i => i.CatalogTypesOfCoffee)
            .OrderBy(c => c.Price)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogCoffeeEntity>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogCoffeeEntity>> SortCoffeeByDescendingPriceAsync(int pageIndex, int pageSize,
        int? categoryFilter)
    {
        IQueryable<CatalogCoffeeEntity> query = _dbContext.CatalogCoffee;

        if (categoryFilter.HasValue)
        {
            query = query.Where(w => w.CatalogCategoryId == categoryFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query
            .Include(i => i.CatalogCategory)
            .Include(i => i.CatalogTypesOfCoffee)
            .OrderByDescending(c => c.Price)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogCoffeeEntity>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogOtherPositionsEntity>> GetOtherPositionsByPageAsync(int pageIndex,
        int pageSize, int? categoryFilter)
    {
        IQueryable<CatalogOtherPositionsEntity> query = _dbContext.CatalogOtherPositions;

        if (categoryFilter.HasValue)
        {
            query = query.Where(w => w.CatalogCategoryId == categoryFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query
            .Include(i => i.CatalogCategory)
            .OrderBy(c => c.Title)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogOtherPositionsEntity>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogOtherPositionsEntity>> SortOtherPositionsByAscendingPriceAsync(int pageIndex,
        int pageSize, int? categoryFilter)
    {
        IQueryable<CatalogOtherPositionsEntity> query = _dbContext.CatalogOtherPositions;

        if (categoryFilter.HasValue)
        {
            query = query.Where(w => w.CatalogCategoryId == categoryFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query
            .Include(i => i.CatalogCategory)
            .OrderBy(c => c.Price)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogOtherPositionsEntity>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogOtherPositionsEntity>> SortOtherPositionsByDescendingPriceAsync(int pageIndex,
        int pageSize, int? categoryFilter)
    {
        IQueryable<CatalogOtherPositionsEntity> query = _dbContext.CatalogOtherPositions;

        if (categoryFilter.HasValue)
        {
            query = query.Where(w => w.CatalogCategoryId == categoryFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query
            .Include(i => i.CatalogCategory)
            .OrderByDescending(c => c.Price)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogOtherPositionsEntity>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogCategoryEntity>> GetCategoriesAsync()
    {
        var totalItems = await _dbContext.CatalogCategories
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogCategories
            .OrderBy(c => c.Title)
            .ToListAsync();

        return new PaginatedItems<CatalogCategoryEntity>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogTypesOfCoffeeEntity>> GetTypesOfCoffeeAsync()
    {
        var totalItems = await _dbContext.CatalogTypesOfCoffee
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogTypesOfCoffee
            .OrderBy(c => c.Title)
            .ToListAsync();

        return new PaginatedItems<CatalogTypesOfCoffeeEntity>() { TotalCount = totalItems, Data = itemsOnPage };
    }
}
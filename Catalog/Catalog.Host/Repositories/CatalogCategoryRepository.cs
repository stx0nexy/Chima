using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogCategoryRepository : ICatalogCategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogCategoryRepository> _logger;

    public CatalogCategoryRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogCategoryRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> CreateAsync(string title)
    {
        var item = await _dbContext.AddAsync(new CatalogCategoryEntity()
        {
            Title = title
        });

        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Created Category {title}");
        return item.Entity.Id;
    }

    public async Task<bool?> DeleteAsync(int id)
    {
        CatalogCategoryEntity result = await _dbContext.CatalogCategories.FirstAsync(c => c.Id == id);
        _dbContext.CatalogCategories.Remove(result);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Deleted Category with id: {id}");
        return true;
    }

    public async Task<CatalogCategoryEntity?> UpdateAsync(CatalogCategoryEntity catalogCategory)
    {
        _dbContext.Entry(catalogCategory).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Updated Category with id: {catalogCategory.Id}");
        return catalogCategory;
    }

    public async Task<CatalogCategoryEntity?> GetByIdAsync(int id)
    {
        var result = await _dbContext.CatalogCategories.Where(i => i.Id == id).FirstOrDefaultAsync();
        _logger.LogInformation($"Returned Category with id: {id}");
        return result;
    }
}
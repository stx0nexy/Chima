using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogOtherPositionsRepository : ICatalogOtherPositionsRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogOtherPositionsRepository> _logger;

    public CatalogOtherPositionsRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogOtherPositionsRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> CreateAsync(string title, decimal price, string subTitle, string description, bool available, string pictureFileName, int catalogCategoryId)
    {
        var item = await _dbContext.AddAsync(new CatalogOtherPositionsEntity()
        {
            Title = title,
            Price = price,
            SubTitle = subTitle,
            Description = description,
            Available = available,
            PictureFileName = pictureFileName,
            CatalogCategoryId = catalogCategoryId
        });

        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Created Position Item {title}");
        return item.Entity.Id;
    }

    public async Task<bool?> DeleteAsync(int id)
    {
        CatalogOtherPositionsEntity result = await _dbContext.CatalogOtherPositions.FirstAsync(c => c.Id == id);
        _dbContext.CatalogOtherPositions.Remove(result);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Deleted Position Item with id: {id}");
        return true;
    }

    public async Task<CatalogOtherPositionsEntity?> UpdateAsync(CatalogOtherPositionsEntity catalogOtherPisition)
    {
        _dbContext.Entry(catalogOtherPisition).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Updated Position Item with id: {catalogOtherPisition.Id}");
        return catalogOtherPisition;
    }

    public async Task<CatalogOtherPositionsEntity?> GetByIdAsync(int id)
    {
        var result = await _dbContext.CatalogOtherPositions.Where(i => i.Id == id).FirstOrDefaultAsync();
        _logger.LogInformation($"Returned Position Item with id: {id}");
        return result;
    }
}
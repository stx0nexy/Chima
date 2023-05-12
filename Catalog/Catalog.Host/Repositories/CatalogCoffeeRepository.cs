using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogCoffeeRepository : ICatalogCoffeeRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogCoffeeRepository> _logger;

    public CatalogCoffeeRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogCoffeeRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> CreateAsync(string title, decimal price, string subTitle, string description, string pictureFileName, int catalogCategoryId, List<CatalogTypesOfCoffeeEntity> catalogTypesOfCoffee)
    {
       var item = await _dbContext.AddAsync(new CatalogCoffeeEntity()
            {
                Title = title,
                Price = price,
                SubTitle = subTitle,
                Description = description,
                PictureFileName = pictureFileName,
                CatalogCategoryId = catalogCategoryId,
                CatalogTypesOfCoffee = catalogTypesOfCoffee 
            });

            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Created Coffee Item {title}");
            return item.Entity.Id;
    }

    public async Task<bool?> DeleteAsync(int id)
    {
        CatalogCoffeeEntity result = await _dbContext.CatalogCoffee.FirstAsync(c => c.Id == id);
        _dbContext.CatalogCoffee.Remove(result);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Deleted Coffee Item with id: {id}");
        return true;
    }

    public async Task<CatalogCoffeeEntity?> UpdateAsync(CatalogCoffeeEntity catalogCoffee)
    {
        _dbContext.Entry(catalogCoffee).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Updated Coffee Item with id: {catalogCoffee.Id}");
        return catalogCoffee;
    }

    public async Task<CatalogCoffeeEntity?> GetByIdAsync(int id)
    {
        var result = await _dbContext.CatalogCoffee.Where(i => i.Id == id).FirstOrDefaultAsync();
        _logger.LogInformation($"Returned Coffee Item with id: {id}");
        return result;
    }
}
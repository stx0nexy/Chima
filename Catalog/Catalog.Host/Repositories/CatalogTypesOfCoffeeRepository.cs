using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogTypesOfCoffeeRepository : ICatalogTypesOfCoffeeRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogTypesOfCoffeeRepository> _logger;

    public CatalogTypesOfCoffeeRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogTypesOfCoffeeRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> CreateAsync(string title, string description,bool available, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogTypesOfCoffeeEntity()
        {
            Title = title,
            Description = description,
            PictureFileName = pictureFileName,
            Available = available
        });

        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Created Type of Coffee {title}");
        return item.Entity.Id;
    }

    public async Task<bool?> DeleteAsync(int id)
    {
        CatalogTypesOfCoffeeEntity result = await _dbContext.CatalogTypesOfCoffee.FirstAsync(c => c.Id == id);
        _dbContext.CatalogTypesOfCoffee.Remove(result);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Deleted Type of Coffee with id: {id}");
        return true;
    }

    public async Task<CatalogTypesOfCoffeeEntity?> UpdateAsync(CatalogTypesOfCoffeeEntity catalogTypeOfCoffee)
    {
        _dbContext.Entry(catalogTypeOfCoffee).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Updated Type of Coffee with id: {catalogTypeOfCoffee.Id}");
        return catalogTypeOfCoffee;
    }

    public async Task<CatalogTypesOfCoffeeEntity?> GetByIdAsync(int id)
    {
        var result = await _dbContext.CatalogTypesOfCoffee.Where(i => i.Id == id).FirstOrDefaultAsync();
        _logger.LogInformation($"Returned Type of Coffee with id: {id}");
        return result;
    }
}
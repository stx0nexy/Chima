using Catalog.Host.Data.Entity;
using Catalog.Host.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CatalogCoffeeEntity> CatalogCoffee { get; set; } = null!;
    public DbSet<CatalogOtherPositionsEntity> CatalogOtherPositions { get; set; } = null!;
    public DbSet<CatalogCategoryEntity> CatalogCategories { get; set; } = null!;
    public DbSet<CatalogTypesOfCoffeeEntity> CatalogTypesOfCoffee { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CatalogCoffeeEntityConfigurations());
        builder.ApplyConfiguration(new CatalogOtherPositionsEntityConfigurations());
        builder.ApplyConfiguration(new CatalogCategoryEntityConfigurations());
        builder.ApplyConfiguration(new CatalogTypesOfCoffeeEntityConfigurations());
    }
}
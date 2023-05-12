using Catalog.Host.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogTypesOfCoffeeEntityConfigurations: IEntityTypeConfiguration<CatalogTypesOfCoffeeEntity>
{
    public void Configure(EntityTypeBuilder<CatalogTypesOfCoffeeEntity> builder)
    {
        builder.ToTable("CatalogTypesOfCoffee");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("catalog_category_hilo")
            .IsRequired();

        builder.Property(cb => cb.Title)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(ci => ci.Description)
            .IsRequired(true);

        builder.Property(ci => ci.PictureFileName)
            .IsRequired(false);
        
        builder.Property(ci => ci.Available)
            .IsRequired(true);
    }
}
using Catalog.Host.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogCoffeeEntityConfigurations: IEntityTypeConfiguration<CatalogCoffeeEntity>
{
    public void Configure(EntityTypeBuilder<CatalogCoffeeEntity> builder)
    {
        builder.ToTable("CatalogCoffee");

        builder.Property(ci => ci.Id)
            .UseHiLo("catalog_coffee_hilo")
            .IsRequired();

        builder.Property(ci => ci.Title)
            .IsRequired(true)
            .HasMaxLength(100);

        builder.Property(ci => ci.SubTitle)
            .IsRequired(true)
            .HasMaxLength(200);

        builder.Property(ci => ci.Description)
            .IsRequired(true);

        builder.Property(ci => ci.PictureFileName)
            .IsRequired(false);

        builder.Property(ci => ci.Price)
            .IsRequired(true);

        builder.HasOne(ci => ci.CatalogCategory)
            .WithMany()
            .HasForeignKey(ci => ci.CatalogCategoryId);

        builder.HasMany(ci => ci.CatalogTypesOfCoffee)
            .WithMany(ci => ci.CatalogCoffee);
    }
}
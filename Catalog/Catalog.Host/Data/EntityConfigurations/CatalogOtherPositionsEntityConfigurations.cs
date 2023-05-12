using Catalog.Host.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogOtherPositionsEntityConfigurations: IEntityTypeConfiguration<CatalogOtherPositionsEntity>
{
    public void Configure(EntityTypeBuilder<CatalogOtherPositionsEntity> builder)
    {
        builder.ToTable("CatalogOtherPositions");

        builder.Property(ci => ci.Id)
            .UseHiLo("catalog_other_positions_hilo")
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

        builder.Property(ci => ci.Available)
            .IsRequired(true);

        builder.HasOne(ci => ci.CatalogCategory)
            .WithMany()
            .HasForeignKey(ci => ci.CatalogCategoryId);
    }
}
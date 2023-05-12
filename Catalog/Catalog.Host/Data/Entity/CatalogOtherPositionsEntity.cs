namespace Catalog.Host.Data.Entity;

public class CatalogOtherPositionsEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public string SubTitle { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string PictureFileName { get; set; } = null!;
    public bool Available { get; set; }
    public int CatalogCategoryId { get; set; }
    public CatalogCategoryEntity? CatalogCategory { get; set; } = null!;
}
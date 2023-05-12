namespace Catalog.Host.Models.Dtos;

public class CatalogOtherPositionsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public string SubTitle { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public bool Available { get; set; }
    public int CatalogCategoryId { get; set; }
    public CatalogCategoryDto? CatalogCategory { get; set; } = null!;
}
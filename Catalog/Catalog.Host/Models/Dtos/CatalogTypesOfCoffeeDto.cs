namespace Catalog.Host.Models.Dtos;

public class CatalogTypesOfCoffeeDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public bool Available { get; set; }
    public List<CatalogCoffeeDto> CatalogCoffee { get; } = new();
}
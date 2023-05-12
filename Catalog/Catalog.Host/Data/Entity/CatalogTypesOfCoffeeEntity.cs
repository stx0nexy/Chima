namespace Catalog.Host.Data.Entity;

public class CatalogTypesOfCoffeeEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string PictureFileName { get; set; } = null!;
    public bool Available { get; set; }
    public List<CatalogCoffeeEntity> CatalogCoffee { get; } = new();
}
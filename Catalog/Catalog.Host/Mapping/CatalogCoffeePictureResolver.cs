using AutoMapper;
using Catalog.Host.Configurations;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.Dtos;
using Microsoft.Extensions.Options;

namespace Catalog.Host.Mapping;

public class CatalogCoffeePictureResolver : IMemberValueResolver<CatalogCoffeeEntity, CatalogCoffeeDto, string, object>
{
    private readonly CatalogConfig _config;

    public CatalogCoffeePictureResolver(IOptionsSnapshot<CatalogConfig> config)
    {
        _config = config.Value;
    }

    public object Resolve(CatalogCoffeeEntity source, CatalogCoffeeDto destination, string sourceMember, object destMember, ResolutionContext context)
    {
        return $"{_config.CdnHost}/{_config.ImgUrl}/{sourceMember}";
    }
}
using AutoMapper;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogCoffeeEntity, CatalogCoffeeDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogCoffeePictureResolver, string>(c => c.PictureFileName));
        CreateMap<CatalogOtherPositionsEntity, CatalogOtherPositionsDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogOtherPositionsPictureResolver, string>(c => c.PictureFileName));
        CreateMap<CatalogCategoryEntity, CatalogCategoryDto>();
        CreateMap<CatalogTypesOfCoffeeEntity, CatalogTypesOfCoffeeDto>();
    }
}
using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogCoffeeService: BaseDataService<ApplicationDbContext>, ICatalogCoffeeService
{
    private readonly ICatalogCoffeeRepository _catalogCoffeeRepository;
    private readonly IMapper _mapper;

    public CatalogCoffeeService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogCoffeeRepository catalogCoffeeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogCoffeeRepository = catalogCoffeeRepository;
        _mapper = mapper;
    }

    public Task<int?> Create(string title, decimal price, string subTitle, string description, string pictureFileName, int catalogCategoryId, List<CatalogTypesOfCoffeeEntity> catalogTypesOfCoffee)
    {
        return ExecuteSafeAsync(() => _catalogCoffeeRepository.CreateAsync(title, price, subTitle, description, pictureFileName, catalogCategoryId, catalogTypesOfCoffee));
    }

    public Task<bool?> Delete(int id)
    {
        return ExecuteSafeAsync(() => _catalogCoffeeRepository.DeleteAsync(id));
    }

    public Task<CatalogCoffeeDto> Update(int id, string title, decimal price, string subTitle, string description, string pictureFileName, int catalogCategoryId, List<CatalogTypesOfCoffeeEntity> catalogTypesOfCoffee)

    {
        return ExecuteSafeAsync(async () =>
        {
            var result = await _catalogCoffeeRepository.UpdateAsync(new CatalogCoffeeEntity()
            {
                Id = id,
                Title = title,
                Price = price,
                SubTitle = subTitle,
                Description = description,
                PictureFileName = pictureFileName,
                CatalogCategoryId = catalogCategoryId,
                CatalogTypesOfCoffee = catalogTypesOfCoffee
            });
            return _mapper.Map<CatalogCoffeeDto>(result);
        });
    }
}
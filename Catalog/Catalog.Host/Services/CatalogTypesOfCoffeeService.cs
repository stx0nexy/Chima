using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogTypesOfCoffeeService: BaseDataService<ApplicationDbContext>, ICatalogTypesOfCoffeeService

{
    private readonly ICatalogTypesOfCoffeeRepository _catalogTypesOfCoffeeRepository;
    private readonly IMapper _mapper;

    public CatalogTypesOfCoffeeService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogTypesOfCoffeeRepository catalogTypesOfCoffeeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogTypesOfCoffeeRepository = catalogTypesOfCoffeeRepository;
        _mapper = mapper;
    }

    public Task<int?> Create(string title, string description,bool available, string pictureFileName)
    {
        return ExecuteSafeAsync(() => _catalogTypesOfCoffeeRepository.CreateAsync(title, description, available, pictureFileName));
    }

    public Task<bool?> Delete(int id)
    {
        return ExecuteSafeAsync(() => _catalogTypesOfCoffeeRepository.DeleteAsync(id));
    }

    public Task<CatalogTypesOfCoffeeDto> Update(int id, string title, string description,bool available, string pictureFileName)

    {
        return ExecuteSafeAsync(async () =>
        {
            var result = await _catalogTypesOfCoffeeRepository.UpdateAsync(new CatalogTypesOfCoffeeEntity()
            {
                Id = id,
                Title = title,
                Available = available,
                Description = description,
                PictureFileName = pictureFileName
            });
            return _mapper.Map<CatalogTypesOfCoffeeDto>(result);
        });
    }
}
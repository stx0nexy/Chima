using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogOtherPositionsService: BaseDataService<ApplicationDbContext>, ICatalogOtherPositionsService
{
    private readonly ICatalogOtherPositionsRepository _сatalogOtherPositionsRepository;
    private readonly IMapper _mapper;

    public CatalogOtherPositionsService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogOtherPositionsRepository сatalogOtherPositionsRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _сatalogOtherPositionsRepository = сatalogOtherPositionsRepository;
        _mapper = mapper;
    }

    public     Task<int?> Create(string title, decimal price, string subTitle, string description,bool available, string pictureFileName, int catalogCategoryId)
    {
        return ExecuteSafeAsync(() => _сatalogOtherPositionsRepository.CreateAsync(title, price, subTitle, description, available, pictureFileName,catalogCategoryId));
    }

    public Task<bool?> Delete(int id)
    {
        return ExecuteSafeAsync(() => _сatalogOtherPositionsRepository.DeleteAsync(id));
    }

    public Task<CatalogOtherPositionsDto> Update(int id, string title, decimal price, string subTitle, string description, string pictureFileName, int catalogCategoryId)

    {
        return ExecuteSafeAsync(async () =>
        {
            var result = await _сatalogOtherPositionsRepository.UpdateAsync(new CatalogOtherPositionsEntity()
            {
                Id = id,
                Title = title,
                Price = price,
                SubTitle = subTitle,
                Description = description,
                PictureFileName = pictureFileName,
                CatalogCategoryId = catalogCategoryId
            });
            return _mapper.Map<CatalogOtherPositionsDto>(result);
        });
    }
}
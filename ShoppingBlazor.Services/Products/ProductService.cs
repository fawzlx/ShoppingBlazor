using ErrorOr;
using Mapster;
using ShoppingBlazor.Databases.Repositories;
using ShoppingBlazor.Entities.Products;
using ShoppingBlazor.Infrastructure.DI;
using ShoppingBlazor.Infrastructure.Results;
using ShoppingBlazor.Services.Products.Dtos;
using ShoppingBlazor.Services.Products.Paginations;

namespace ShoppingBlazor.Services.Products;

public class ProductService(IRepository<Stuff> stuffDao, IRepository<Brand> brandDao, IRepository<Category> categoryDao)
    : IProductService, IScopedService
{
    public ErrorOr<ResultList<StuffDto>> Stuffs(StuffPagination request)
    {
        var stuffs = stuffDao.Read();

        var filtersStuff = request.Apply(stuffs);

        return new ResultList<StuffDto>(filtersStuff.Results.Select(x => new StuffDto(x))
            .ToList(), filtersStuff.Total);
    }

    public ErrorOr<StuffDto> AddStuff(AddStuffRequest request)
    {
        var brand = brandDao.ReadById(request.BrandId);
        if (brand is null) return Error.NotFound("برند مورد نظر یافت نشد");

        var category = categoryDao.ReadById(request.CategoryId);
        if (category is null) return Error.NotFound("دسته بندی مورد نظر یافت نشد");

        var stuff = request.Adapt<Stuff>();
        stuff.Category = category;
        stuff.Brand = brand;

        return new StuffDto(stuffDao.Create(stuff));
    }

    public ErrorOr<StuffDto> EditStuff(EditStuffRequest request)
    {
        var brand = brandDao.ReadById(request.BrandId);
        if (brand is null) return Error.NotFound("برند مورد نظر یافت نشد");

        var category = categoryDao.ReadById(request.CategoryId);
        if (category is null) return Error.NotFound("دسته بندی مورد نظر یافت نشد");

        var stuff = request.Adapt<Stuff>();
        stuff.Category = category;
        stuff.Brand = brand;

        return new StuffDto(stuffDao.Update(stuff));
    }

    public ErrorOr<StuffDto> RemoveStuff(int stuffId)
    {
        var stuff = stuffDao.DeleteById(stuffId);

        if (stuff is null) return Error.NotFound();

        return new StuffDto(stuff);
    }

    public ErrorOr<ResultList<CategoryDto>> Categories(CategoryPagination pagination)
    {
        var categories = categoryDao.Read();

        var filtersCategories = pagination.Apply(categories);

        return new ResultList<CategoryDto>(filtersCategories.Results.Select(x => new CategoryDto(x))
            .ToList(), filtersCategories.Total);
    }

    public ErrorOr<ResultList<BrandDto>> Brands(BrandPagination pagination)
    {
        var brands = brandDao.Read();

        var filtersBrands = pagination.Apply(brands);

        return new ResultList<BrandDto>(filtersBrands.Results.Select(x => new BrandDto(x))
            .ToList(), filtersBrands.Total);
    }
}
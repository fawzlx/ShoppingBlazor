using ErrorOr;
using Mapster;
using ShoppingBlazor.Databases.Repositories;
using ShoppingBlazor.Entities.Products;
using ShoppingBlazor.Infrastructure.DI;
using ShoppingBlazor.Services.Products.Dtos;
using ShoppingBlazor.Services.Products.Paginations;

namespace ShoppingBlazor.Services.Products;

public class ProductService(IRepository<Stuff> stuffDao, IRepository<Brand> brandDao, IRepository<Category> categoryDao) : IProductService, IScopedService
{
    public ErrorOr<IList<StuffDto>> Stuffs(StuffPagination request)
    {
        // return new List<StuffDto>
        // {
        //     new StuffDto(1, "sdf", "sdfs", "sdfs", null, 8, 1250000, DateTime.Now, DateTime.Now.AddDays(15))
        // };

        var stuffs = stuffDao.Read();

        var filtersStuff = request.Apply(stuffs);

        return filtersStuff.Result.Select(x => new StuffDto(x))
            .ToList();
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
}
using ErrorOr;
using ShoppingBlazor.Infrastructure.Results;
using ShoppingBlazor.Services.Products.Dtos;
using ShoppingBlazor.Services.Products.Paginations;

namespace ShoppingBlazor.Services.Products;

public interface IProductService
{
    ErrorOr<ResultList<StuffDto>> Stuffs(StuffPagination request);

    ErrorOr<StuffDto> AddStuff(AddStuffRequest request);

    ErrorOr<StuffDto> EditStuff(EditStuffRequest request);

    ErrorOr<StuffDto> RemoveStuff(int stuffId);

    ErrorOr<ResultList<CategoryDto>> Categories(CategoryPagination pagination);

    ErrorOr<ResultList<BrandDto>> Brands(BrandPagination pagination);
}
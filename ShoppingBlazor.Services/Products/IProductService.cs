using ErrorOr;
using ShoppingBlazor.Services.Products.Dtos;
using ShoppingBlazor.Services.Products.Paginations;

namespace ShoppingBlazor.Services.Products;

public interface IProductService
{
    ErrorOr<IList<StuffDto>> Stuffs(StuffPagination request);

    ErrorOr<StuffDto> AddStuff(AddStuffRequest request);

    ErrorOr<StuffDto> EditStuff(EditStuffRequest request);

    ErrorOr<StuffDto> RemoveStuff(int stuffId);

    ErrorOr<IList<CategoryDto>> Categories(CategoryPagination pagination);

    ErrorOr<IList<BrandDto>> Brands(BrandPagination pagination);
}
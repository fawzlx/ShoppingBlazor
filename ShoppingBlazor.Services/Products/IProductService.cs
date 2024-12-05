using ErrorOr;
using ShoppingBlazor.Services.Products.Dtos;
using ShoppingBlazor.Services.Products.Paginations;

namespace ShoppingBlazor.Services.Products;

public interface IProductService
{
    ErrorOr<IList<StuffDto>> Stuffs(StuffPagination request);

    ErrorOr<StuffDto> AddStuff(AddStuffRequest request);
}
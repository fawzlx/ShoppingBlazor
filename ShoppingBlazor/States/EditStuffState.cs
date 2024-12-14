using ShoppingBlazor.Infrastructure.DI;
using ShoppingBlazor.Services.Products;
using ShoppingBlazor.Services.Products.Dtos;

namespace ShoppingBlazor.States;

public class EditStuffState(IProductService productService) : DialogState<StuffDto>
{
    public void Confirm(EditStuffRequest request)
    {
        productService.EditStuff(request);

        Item = null;

        Hide();
    }
}
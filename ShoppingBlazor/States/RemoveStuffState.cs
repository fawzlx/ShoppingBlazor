using ShoppingBlazor.Infrastructure.DI;
using ShoppingBlazor.Services.Products;
using ShoppingBlazor.Services.Products.Dtos;

namespace ShoppingBlazor.States;

public class RemoveStuffState(IProductService productService) : DialogState<StuffDto>
{
    public void Confirm()
    {
        productService.RemoveStuff(Item!.Id);

        Item = null;

        Hide();
    }
}
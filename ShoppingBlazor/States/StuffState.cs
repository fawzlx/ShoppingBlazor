using ShoppingBlazor.Infrastructure.DI;
using ShoppingBlazor.Services.Products;
using ShoppingBlazor.Services.Products.Dtos;

namespace ShoppingBlazor.States;

public class AddStuffState(IProductService productService) : DialogState
{
    public void Confirm(AddStuffRequest addStuffRequest)
    {
        productService.AddStuff(addStuffRequest);

        Hide();
    }
}
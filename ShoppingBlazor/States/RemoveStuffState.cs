using ShoppingBlazor.Infrastructure.DI;
using ShoppingBlazor.Services.Products;
using ShoppingBlazor.Services.Products.Dtos;

namespace ShoppingBlazor.States;

public class RemoveStuffState(IProductService productService) : DialogState
{
    public StuffDto? Stuff { get; private set; }

    public void SetId(StuffDto stuff)
    {
        Stuff = stuff;

        Show();
    }

    public void Confirm()
    {
        productService.RemoveStuff(Stuff!.Id);

        Stuff = null;

        Hide();
    }
}
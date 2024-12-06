using ShoppingBlazor.Infrastructure.DI;
using ShoppingBlazor.Services.Products;
using ShoppingBlazor.Services.Products.Dtos;

namespace ShoppingBlazor.States;

public class EditStuffState(IProductService productService) : DialogState
{
    public StuffDto? Stuff { get; private set; }

    public void SetStuff(StuffDto stuff)
    {
        Stuff = stuff;

        Show();
    }

    public void Confirm(EditStuffRequest request)
    {
        productService.EditStuff(request);

        Stuff = null;

        Hide();
    }
}
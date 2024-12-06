namespace ShoppingBlazor.Infrastructure.DI;

public class DialogState : IState
{
    public bool ShowDialog { get; private set; }

    public void Show()
    {
        ShowDialog = true;
    }

    public void Hide()
    {
        ShowDialog = false;
    }
}
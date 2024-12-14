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

public class DialogState<T> : IState
{
    public T? Item { get; protected set; }

    public bool ShowDialog { get; private set; }

    public void Show(T item)
    {
        Item = item;

        ShowDialog = true;
    }

    public void Hide()
    {
        ShowDialog = false;
    }
}
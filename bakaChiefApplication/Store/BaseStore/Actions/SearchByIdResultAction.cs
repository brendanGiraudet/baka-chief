namespace bakaChiefApplication.Store.BaseStore.Actions;

public class SearchByIdResultAction<T>
{
    public T Item { get; }

    public SearchByIdResultAction(T item)
    {
        Item = item;
    }
}
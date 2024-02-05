namespace bakaChiefApplication.Store.Nutriments.Actions;

public class SearchByIdResultAction<T>
{
    public T Item { get; }

    public SearchByIdResultAction(T item)
    {
        Item = item;
    }
}
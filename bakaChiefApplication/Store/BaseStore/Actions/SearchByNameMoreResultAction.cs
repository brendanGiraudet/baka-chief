namespace bakaChiefApplication.Store.BaseStore.Actions;

public class SearchByNameMoreResultAction<T>
{
    public IEnumerable<T> SearchedItems { get; }

    public SearchByNameMoreResultAction(IEnumerable<T> searchedItems)
    {
        SearchedItems = searchedItems;
    }
}
namespace bakaChiefApplication.Store.BaseStore.Actions;

public class SearchByNameResultAction<T>
{
    public IEnumerable<T> SearchedItems { get; }

    public SearchByNameResultAction(IEnumerable<T> searchedItems)
    {
        SearchedItems = searchedItems;
    }
}
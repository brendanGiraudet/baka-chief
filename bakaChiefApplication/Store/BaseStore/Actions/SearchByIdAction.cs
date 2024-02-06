namespace bakaChiefApplication.Store.BaseStore.Actions;

public class SearchByIdAction<T>
{
    public string ItemId { get; }

    public SearchByIdAction(string itemId)
    {
        ItemId = itemId;
    }
}
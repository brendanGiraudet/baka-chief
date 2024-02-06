namespace bakaChiefApplication.Store.BaseStore.Actions;

public class DeleteAction<T>
{
    public string ItemIdToRemove { get; }

    public DeleteAction(string itemIdToRemove)
    {
        ItemIdToRemove = itemIdToRemove;
    }
}
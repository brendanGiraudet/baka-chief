namespace bakaChiefApplication.Store.BaseStore.Actions;

public class UpdateAction<T>
{
    public T ItemToUpdate { get; }
    
    public string ItemIdToUpdate { get; }

    public UpdateAction(T itemToUpdate, string itemIdToUpdate)
    {
        ItemToUpdate = itemToUpdate;
        ItemIdToUpdate = itemIdToUpdate;
    }
}
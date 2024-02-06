namespace bakaChiefApplication.Store.BaseStore.Actions;

public class DeleteSucceedAction<T>
{
    public string DeletedItemId { get; }

    public DeleteSucceedAction(string deletedItemId)
    {
        DeletedItemId = deletedItemId;
    }
}
namespace bakaChiefApplication.Store.BaseStore.Actions;

public class UpdateSucceedAction<T>
{
    public T UpdatedItem { get; set; }

    public UpdateSucceedAction(T updatedItem)
    {
        UpdatedItem = updatedItem;
    }
}
namespace bakaChiefApplication.Store.BaseStore.Actions;

public class CreateSucceedAction<T>
{
    public T CreatedItem { get; set; }

    public CreateSucceedAction(T createdItem)
    {
        CreatedItem = createdItem;
    }
}
namespace bakaChiefApplication.Store.BaseStore.Actions;

public class CreateAction<T>
{
    public T ItemToCreate { get; set; }

    public CreateAction(T itemToCreate)
    {
        ItemToCreate = itemToCreate;
    }
}
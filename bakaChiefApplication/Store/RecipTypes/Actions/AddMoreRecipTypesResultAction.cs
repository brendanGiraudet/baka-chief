namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class AddMoreRecipTypesResultAction
{
    public IEnumerable<Models.RecipType> SearchedRecipTypes { get; }

    public AddMoreRecipTypesResultAction(IEnumerable<Models.RecipType> searchedRecipTypes)
    {
        SearchedRecipTypes = searchedRecipTypes;
    }
}
namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class RecipTypeSearchByNameResultAction
{
    public IEnumerable<Models.RecipType> SearchedRecipTypes { get; }

    public RecipTypeSearchByNameResultAction(IEnumerable<Models.RecipType> searchedRecipTypes)
    {
        SearchedRecipTypes = searchedRecipTypes;
    }
}
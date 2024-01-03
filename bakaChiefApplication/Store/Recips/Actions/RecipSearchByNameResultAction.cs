namespace bakaChiefApplication.Store.Recips.Actions;

public class RecipSearchByNameResultAction
{
    public IEnumerable<Models.Recip> SearchedRecips { get; }

    public RecipSearchByNameResultAction(IEnumerable<Models.Recip> searchedRecips)
    {
        SearchedRecips = searchedRecips;
    }
}
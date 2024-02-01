namespace bakaChiefApplication.Store.Recips.Actions;

public class AddMoreRecipsResultAction
{
    public IEnumerable<Models.Recip> SearchedRecips { get; }

    public AddMoreRecipsResultAction(IEnumerable<Models.Recip> searchedRecips)
    {
        SearchedRecips = searchedRecips;
    }
}
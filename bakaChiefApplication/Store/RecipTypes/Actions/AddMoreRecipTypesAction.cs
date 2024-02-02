namespace bakaChiefApplication.Store.Recips.Actions;

public class AddMoreRecipsAction
{
    public string RecipSearchTerm { get; }
    
    public int Take { get; }
    
    public int Skip { get; }

    public AddMoreRecipsAction(string recipSearchTerm, int take, int skip)
    {
        RecipSearchTerm = recipSearchTerm;
        Take = take;
        Skip = skip;
    }
}
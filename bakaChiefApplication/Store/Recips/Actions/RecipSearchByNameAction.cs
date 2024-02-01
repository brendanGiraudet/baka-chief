namespace bakaChiefApplication.Store.Recips.Actions;

public class RecipSearchByNameAction
{
    public string RecipSearchTerm { get; }
    
    public int Take { get; }

    public RecipSearchByNameAction(string recipSearchTerm, int take)
    {
        RecipSearchTerm = recipSearchTerm;
        Take = take;
    }
}
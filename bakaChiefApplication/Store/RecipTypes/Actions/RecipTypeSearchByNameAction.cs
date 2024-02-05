namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class RecipTypeSearchByNameAction
{
    public string RecipTypeSearchTerm { get; }
    
    public int? Take { get; }
    
    public int? Skip { get; }

    public RecipTypeSearchByNameAction(string recipTypeSearchTerm, int? take = null, int? skip = null)
    {
        RecipTypeSearchTerm = recipTypeSearchTerm;
        Take = take;
        Skip = skip;
    }
}
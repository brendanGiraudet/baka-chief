namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class AddMoreRecipTypesAction
{
    public string RecipTypeSearchTerm { get; }
    
    public int Take { get; }
    
    public int Skip { get; }

    public AddMoreRecipTypesAction(string recipTypeSearchTerm, int take, int skip)
    {
        RecipTypeSearchTerm = recipTypeSearchTerm;
        Take = take;
        Skip = skip;
    }
}
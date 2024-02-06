namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class AddMoreRecipTypesAction
{
    public string RecipTypeSearchTerm { get; }
    
    public int Take { get; }
    
    public int Skip { get; }

    public AddMoreRecipTypesAction(string recipSearchTerm, int take, int skip)
    {
        RecipTypeSearchTerm = recipSearchTerm;
        Take = take;
        Skip = skip;
    }
}
namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class RecipTypeSearchByNameAction
{
    public string RecipTypeSearchTerm { get; }

    public RecipTypeSearchByNameAction(string recipTypeSearchTerm)
    {
        RecipTypeSearchTerm = recipTypeSearchTerm;
    }
}
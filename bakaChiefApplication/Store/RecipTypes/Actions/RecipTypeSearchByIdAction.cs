namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class RecipTypeSearchByIdAction
{
    public string RecipTypeSearchTerm { get; }

    public RecipTypeSearchByIdAction(string recipTypeSearchTerm)
    {
        RecipTypeSearchTerm = recipTypeSearchTerm;
    }
}
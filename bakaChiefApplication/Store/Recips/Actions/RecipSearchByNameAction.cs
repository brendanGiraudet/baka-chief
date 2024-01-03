namespace bakaChiefApplication.Store.Recips.Actions;

public class RecipSearchByNameAction
{
    public string RecipSearchTerm { get; }

    public RecipSearchByNameAction(string recipSearchTerm)
    {
        RecipSearchTerm = recipSearchTerm;
    }
}
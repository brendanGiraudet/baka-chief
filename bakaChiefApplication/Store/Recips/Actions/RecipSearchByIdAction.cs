namespace bakaChiefApplication.Store.Recips.Actions;

public class RecipSearchByIdAction
{
    public string RecipSearchTerm { get; }

    public RecipSearchByIdAction(string recipSearchTerm)
    {
        RecipSearchTerm = recipSearchTerm;
    }
}
namespace bakaChiefApplication.Store.Recips.Actions;

public class RecipSearchByIdAction
{
    public string RecipId { get; }

    public RecipSearchByIdAction(string recipId)
    {
        RecipId = recipId;
    }
}